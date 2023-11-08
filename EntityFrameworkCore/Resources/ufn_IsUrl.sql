RETURN
    CASE WHEN @value LIKE '%://%'
    -- OR @url LIKE 'http://%'
    -- OR @url LIKE 'ftp://%'
    -- OR @url LIKE 'tg://%'
    -- OR @url LIKE 'telnet://%'
    THEN 1
ELSE 0 END
