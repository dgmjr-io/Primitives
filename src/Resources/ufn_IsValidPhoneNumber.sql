SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [{schema}].[{functionName}](@phoneNumber as varchar(15))
RETURNS BIT
AS
BEGIN
    RETURN CASE
        WHEN @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
        OR @phoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    THEN 1 ELSE 0 END
END
GO
