namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MovieGenres ON");
            Sql("INSERT INTO MovieGenres (MovieGenreId, Name) VALUES (1,'Comedia')");
            Sql("INSERT INTO MovieGenres (MovieGenreId, Name) VALUES (2,'Drama')");
            Sql("INSERT INTO MovieGenres (MovieGenreId, Name) VALUES (3,'Familiar')");
            Sql("INSERT INTO MovieGenres (MovieGenreId, Name) VALUES (4,'Acci�n')");
        }
        
        public override void Down()
        {
        }
    }
}
