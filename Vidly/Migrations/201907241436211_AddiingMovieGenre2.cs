namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddiingMovieGenre2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_MovieGenreId" });
            RenameColumn(table: "dbo.Movies", name: "MovieGenre_MovieGenreId", newName: "MovieGenreId");
            AlterColumn("dbo.Movies", "MovieGenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "MovieGenreId", cascadeDelete: true);
            DropColumn("dbo.Movies", "MoviesGenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MoviesGenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            AlterColumn("dbo.Movies", "MovieGenreId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "MovieGenreId", newName: "MovieGenre_MovieGenreId");
            CreateIndex("dbo.Movies", "MovieGenre_MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenre_MovieGenreId", "dbo.MovieGenres", "MovieGenreId");
        }
    }
}
