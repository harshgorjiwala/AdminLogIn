USE [UserInformation]
GO

/****** Object:  StoredProcedure [dbo].[SP_getUSer]    Script Date: 2020-10-31 2:02:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_getUser]
-- procedure returns all rows from the customer table
AS BEGIN
  SELECT *
  FROM UserInfo;
END;
GO


