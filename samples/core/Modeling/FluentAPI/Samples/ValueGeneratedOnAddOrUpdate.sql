﻿CREATE TRIGGER [dbo].[Blogs_UPDATE] ON [dbo].[Blogs]
	AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
                  
	IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
	
	DECLARE @Id INT
		
	SELECT @Id = INSERTED.BlogId
	FROM INSERTED
          
	UPDATE dbo.Blogs
	SET LastUpdated = GETDATE()
	WHERE BlogId = @Id
END