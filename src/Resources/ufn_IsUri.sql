CREATE OR ALTER FUNCTION [{schema}].[{functionName}](@uri as nvarchar(2048)) RETURNS BIT AS
BEGIN
  RETURN CASE
    WHEN @uri LIKE '%:%' THEN 1
    ELSE 0
  END
END
