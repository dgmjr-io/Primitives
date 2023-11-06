SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  OR ALTER    FUNCTION [{schema}].[{functionName}](@url as nvarchar(2048)) RETURNS BIT AS
BEGIN
    RETURN
        CASE WHEN @url LIKE '%://%'
        -- OR @url LIKE 'http://%'
        -- OR @url LIKE 'ftp://%'
        -- OR @url LIKE 'tg://%'
        -- OR @url LIKE 'telnet://%'
        THEN 1
    ELSE 0 END
END
GO
