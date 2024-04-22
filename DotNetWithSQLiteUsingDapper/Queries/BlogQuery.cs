namespace DotNetWithSQLiteUsingDapper.Queries
{
    public class BlogQuery
    {
        public static string CreateBlogTable =
   @"CREATE TABLE IF NOT EXISTS Tbl_Blog 
    (BlogId TEXT NOT NULL, 
    BlogTitle TEXT NOT NULL, 
    BlogAuthor TEXT NOT NULL, 
    BlogContent TEXT NOT NULL)";


        public static string Insert =
   @"INSERT INTO Tbl_Blog (BlogId, BlogTitle, BlogAuthor, BlogContent) 
    VALUES (@BlogId, @BlogTitle, @BlogAuthor, @BlogContent)";

        public static string GetAll = @"SELECT * FROM Tbl_Blog";

        public static string Update = @"UPDATE Tbl_Blog SET 
                                            BlogTitle = @BlogTitle,
                                            BlogAuthor = @BlogAuthor,
                                            BlogContent = @BlogContent 
                                            WHERE BlogId = @BlogId";

        public static string Delete = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

        public static string GetDataById = @"SELECT * FROM Tbl_BLog WHERE BlogId = @BlogId";
    }
}
