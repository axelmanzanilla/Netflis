using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLiteDb
{
    public sealed class Membership
    {
        public int Id { get; }
        public string Description { get; }
        public decimal Cost { get; }

        public Membership(int id, string description, decimal cost)
        {
            Id = id;
            Description = description;
            Cost = cost;
        }
    }

    public sealed class User
    {
        public int Id { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string BirthDay { get; }
        public string Email { get; }
        public string Password { get; }
        public string DeadLine { get; }
        public Membership membership { get; }

        public User(int id, string username, string firstName, string lastName, string birthDay,
            string email, string password, string deadLine, Membership membership)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Email = email;
            Password = password;
            DeadLine = deadLine;
            this.membership = membership;
        }
    }

    public sealed class Movie
    {
        public string Code { get; }
        public string Title { get; }
        public string Image { get; }
        public string Genre { get; }
        public int Year { get; }
        public int Seconds { get; }
        public Membership membership { get; }
        public string Description { get; }
        public List<Review> Reviews { get; }
        public float ScoreTotal
        {
            get
            {
                float aux = 0;
                Reviews.ForEach(r =>
                {
                    aux += r.Score;
                });
                return aux / Reviews.Count;
            }
        }

        public Movie(string code, string title, string image, string genre, int year,
            int seconds, Membership membership, string description, List<Review> reviews)
        {
            Code = code;
            Title = title;
            Image = image;
            Genre = genre;
            Year = year;
            Seconds = seconds;
            this.membership = membership;
            Description = description;
            Reviews = reviews;
        }
    }

    public sealed class Review
    {
        public string CodeMovie { get; }
        public int Score { get; }
        public string Commentary { get; }
        public User Usuario { get; }

        public Review(string codeMovie, int score, string commentary, User user)
        {
            CodeMovie = codeMovie;
            Score = score;
            Commentary = commentary;
            Usuario = user;
        }
    }

    public sealed class MovieRecord
    {
        public User user { get; }
        public Movie movie { get; }
        public int SecondsSeen { get; }
        public bool Watched { get; }

        public MovieRecord(User user, Movie movie, int secondsSeen, bool watched)
        {
            this.user = user;
            this.movie = movie;
            SecondsSeen = secondsSeen;
            Watched = watched;
        }
    }


    public partial class SQLiteConn
    {
        public List<Membership> GetMemberships()
        {
            List<Membership> memberships = new List<Membership>();
            string query = "SELECT * FROM memberships_types";

            using(SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    memberships.Add(new Membership(rs.GetInt32("id"),
                                                   rs.GetString("description"),
                                                   (decimal)rs.GetInt32("cost")));
                }
            }
            return memberships;
        }

        public List<MovieRecord> GetMovieRecordsByUser(User user)
        {
            List<MovieRecord> movieRecords = new List<MovieRecord>();

            string query = $"SELECT movie_code, seconds_seen, watched FROM movies_record WHERE membership_id = {user.Id}";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movieRecords.Add(new MovieRecord(user,
                                                     GetMoviesByMembership().Find(m => m.Code == rs.GetString("movie_code")),
                                                     rs.GetInt32("seconds_seen"),
                                                     rs.GetInt32("watched") != 0));
                }
            }

            return movieRecords;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string query = $"SELECT * FROM memberships";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    users.Add(new User(rs.GetInt32("id"),
                                       rs.GetString("username"),
                                       rs.GetString("fname"),
                                       rs.GetString("lname"),
                                       rs.GetString("birthday"),
                                       rs.GetString("email"),
                                       rs.GetString("password"),
                                       rs.GetString("deadline"),
                                       GetMemberships().Find(m => m.Id == rs.GetInt32("membershiptype_id"))));
                }
            }
            return users;
        }

        private List<Review> GetReviews()
        {
            List<Review> reviews = new List<Review>();
            string query = "SELECT * FROM film_review";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    reviews.Add(new Review(rs.GetString("movie_code"),
                                           rs.GetInt32("score"),
                                           rs.GetString("commentary"),
                                           GetUsers().Find(u => u.Id == rs.GetInt32("membership_id"))));
                }
            }

            return reviews;
        }

        public List<Movie> GetMoviesByMembership(int membership = 1)
        {
            List<Movie> movies = new List<Movie>();

            string query = $"SELECT mv.code, mv.title, mv.image, gr.description AS genre, " +
                           $"mv.year, mv.seconds, mv.membership_types_id AS id, mv.description, " +
                           $"mv.code AS code2 " +
                           $"FROM movies mv " +
                           $"INNER JOIN genres gr ON(mv.genre_id = gr.id)";
            if (membership == 0) query += $"WHERE mv.membership_types_id = 0";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movies.Add(new Movie(rs.GetString("code"),
                                         rs.GetString("title"),
                                         rs.GetString("image"),
                                         rs.GetString("genre"),
                                         rs.GetInt32("year"),
                                         rs.GetInt32("seconds"),
                                         GetMemberships().Find(m => m.Id == rs.GetInt32("id")),
                                         rs.GetString("description"),
                                         GetReviews().FindAll(r=>r.CodeMovie==rs.GetString("code2"))));
                }
            }

            return movies;
        }

        public List<Movie> GetMoviesSeen(User user)
        {
            List<Movie> movies = new List<Movie>();
            string query = $"SELECT mv.code, mv.title, mv.image, gr.description AS genre, " +
                           $"mv.year, mv.seconds, mv.membership_types_id AS id, mv.description, " +
                           $"mv.code AS code2 " +
                           $"FROM movies_record mr " +
                           $"INNER JOIN movies mv ON (mv.code = mr.movie_code) " +
                           $"INNER JOIN genres gr ON (mv.genre_id = gr.id) " +
                           $"WHERE mr.membership_id = {user.Id} " +
                           $"LIMIT 5";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movies.Add(new Movie(rs.GetString("code"),
                                         rs.GetString("title"),
                                         rs.GetString("image"),
                                         rs.GetString("genre"),
                                         rs.GetInt32("year"),
                                         rs.GetInt32("seconds"),
                                         GetMemberships().Find(m => m.Id == rs.GetInt32("id")),
                                         rs.GetString("description"),
                                         GetReviews().FindAll(r=>r.CodeMovie==rs.GetString("code2"))));
                }
            }

            return movies;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            List<Movie> movies = new List<Movie>();
            string query = $"SELECT mv.code, mv.title, mv.image, gr.description AS genre, " +
                           $"mv.year, mv.seconds, mv.membership_types_id AS id, mv.description, " +
                           $"mv.code AS code2 " +
                           $"FROM movies mv " +
                           $"INNER JOIN genres gr ON(mv.genre_id = gr.id) " +
                           $"WHERE gr.description LIKE '{genre}' " +
                           $"LIMIT 5";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movies.Add(new Movie(rs.GetString("code"),
                                         rs.GetString("title"),
                                         rs.GetString("image"),
                                         rs.GetString("genre"),
                                         rs.GetInt32("year"),
                                         rs.GetInt32("seconds"),
                                         GetMemberships().Find(m => m.Id == rs.GetInt32("id")),
                                         rs.GetString("description"),
                                         GetReviews().FindAll(r => r.CodeMovie == rs.GetString("code2"))));
                }
            }
            return movies;
        }

        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();
            string query = $"SELECT description AS genre " +
                           $"FROM genres";
            genres.Add("Todos");
            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    genres.Add(rs.GetString("genre"));
                }
            }
            return genres;
        }

        public string SecondsToHours(int time)
        {
            TimeSpan t = new TimeSpan(0, 0, time);
            string aux = "0";
            string hours = t.Hours.ToString();
            string minutes = t.Minutes.ToString();
            string seconds = t.Seconds.ToString();

            if (t.Hours < 10) hours = aux + hours;
            if (t.Minutes < 10) minutes = aux + minutes;
            if (t.Seconds < 10) seconds = aux + seconds;
            return $"{hours}:{minutes}:{seconds}";
        }

        public List<Movie> GetMoviesByRanked()
        {
            List<Movie> movies = new List<Movie>();
            string query = $"SELECT mv.code, mv.title, mv.image, gr.description AS genre, " +
                           $"mv.year, mv.seconds, mv.membership_types_id AS id, mv.description, " +
                           $"AVG(score) AS score " +
                           $"FROM movies mv " +
                           $"INNER JOIN genres gr ON (mv.genre_id = gr.id) " +
                           $"INNER JOIN film_review fr ON (fr.movie_code = mv.code) " +
                           $"GROUP BY code ORDER BY score DESC LIMIT 5";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movies.Add(new Movie(rs.GetString("code"),
                                         rs.GetString("title"),
                                         rs.GetString("image"),
                                         rs.GetString("genre"),
                                         rs.GetInt32("year"),
                                         rs.GetInt32("seconds"),
                                         GetMemberships().Find(m => m.Id == rs.GetInt32("id")),
                                         rs.GetString("description"),
                                         GetReviews().FindAll(r => r.CodeMovie == rs.GetString("code"))));
                }
            }
            return movies;
        }

        public List<Movie> SearchMovies(int membership, string title, string genre = "",string yearmin = "",
            string yearmax = "", string calmin = "", string calmax = "")
        {
            List<Movie> movies = new List<Movie>();

            string where = $"WHERE title LIKE '%{title}%'";
            if (genre != "Todos") where += $" AND genre = '{genre}'";
            if (yearmin != "") where += $" AND year >= {yearmin}";
            if (yearmax != "") where += $" AND year <= {yearmax}";

            if (membership == 0) where += $" AND membership_types_id = 0";

                string query = $"SELECT mv.code, mv.title, mv.image, gr.description AS genre, " +
                               $"mv.year, mv.seconds, mv.membership_types_id AS id, mv.description, " +
                               $"mv.code AS code2 " +
                               $"FROM movies mv " +
                               $"INNER JOIN genres gr ON(gr.id = mv.genre_id) {where}";

            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    movies.Add(new Movie(rs.GetString("code"),
                                         rs.GetString("title"),
                                         rs.GetString("image"),
                                         rs.GetString("genre"),
                                         rs.GetInt32("year"),
                                         rs.GetInt32("seconds"),
                                         GetMemberships().Find(m => m.Id == rs.GetInt32("id")),
                                         rs.GetString("description"),
                                         GetReviews().FindAll(r => r.CodeMovie == rs.GetString("code2"))));
                }
            }

            return movies;
        }

        public string GetDate(DateTime date)
        {
            string aux = "0";
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();

            if (date.Day < 10) day = aux + day;
            if (date.Month < 10) month = aux + month;

            return $"{year}-{month}-{day}";
        }

        public int GetSecond(User user, Movie movie)
        {
            int aux = 0;
            string query = $"SELECT seconds_seen AS second FROM movies_record WHERE membership_id = {user.Id} AND movie_code = '{movie.Code}'";
            using (SQLiteRecordSet rs = ExecuteQuery(query))
            {
                while (rs.NextRecord())
                {
                    aux = rs.GetInt32("second");
                }
            }
            return aux;
        }

        public string GetGenreFav(User user)
        {
            string genre = "Familiar";
            using (SQLiteRecordSet rs = ExecuteQuery($"SELECT MAX(qty), genre " +
                                                     $"FROM( " +
                                                     $"SELECT COUNT(*) AS qty, g.description AS genre " +
                                                     $"FROM movies_record mr " +
                                                     $"INNER JOIN movies m ON (m.code = mr.movie_code) " +
                                                     $"INNER JOIN genres g ON (g.id = m.genre_id) " +
                                                     $"WHERE mr.membership_id = {user.Id} " +
                                                     $"GROUP BY m.genre_id)"))
            {
                while (rs.NextRecord())
                {
                    genre = rs.GetString("genre");
                }
            }
            return genre;
        }
    }
}