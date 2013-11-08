-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE esl_get_last_userid_by_deviceid
	-- Add the parameters for the stored procedure here
	@esl_user_id nvarchar(30) = "saber",
	@esl_device_id nvarchar(64) = "000000000000000000"
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT modifyDateTime,REPLACE(REPLACE (mobilenumber,char(8),'*'),char(9),'*') as mobilenumber FROM esl_tbl_users_devices
	where idUser = @esl_user_id
END
GO


	SELECT modifyDateTime,REPLACE(REPLACE (mobilenumber,char(8),'*'),char(9),'*') as mobilenumber FROM esl_tbl_users_devices
	where idUser = 'amin'