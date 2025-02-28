USE [rencata]
GO
/****** Object:  StoredProcedure [dbo].[sp_employee_master]    Script Date: 06-08-2020 17:57:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_employee_master]
(
@employee_id int,
@employee_name varchar(50)=null,
@father_name varchar(50)=null,
@mother_name varchar(50)=null,
@DOB date =null,
@gender int =null,
@marital_status	int =null,
@Address nvarchar(MAX)=null,
@Dml_Indicator varchar(10)
)
AS
BEGIN
if(@Dml_Indicator='I')
BEGIN
INSERT INTO tbl_employee_master(employee_name,father_name,mother_name,DOB,gender,marital_status,Address)
values(@employee_name,@father_name,@mother_name,@DOB,@gender,@marital_status,@Address);
SELECT 'success' as stringmsg;
END
else if(@Dml_Indicator='S')
BEGIN
select employee_id,employee_name,father_name,mother_name,convert(varchar,DOB,103)as DOB,gender,marital_status,Address from tbl_employee_master;
END
else if(@Dml_Indicator='D')
BEGIN
delete from tbl_employee_master where employee_id=@employee_id;
SELECT 'success' as stringmsg;
END
else if(@Dml_Indicator='U')
BEGIN
update tbl_employee_master set employee_name=@employee_name,
father_name=@father_name,mother_name=@mother_name,DOB=@DOB,gender=@gender,marital_status=@marital_status,Address=@Address
where employee_id=@employee_id;
SELECT 'success' as stringmsg;
END
else if(@Dml_Indicator='E')
BEGIN
select employee_id,employee_name,father_name,mother_name,convert(varchar,DOB,105)as DOB,gender,marital_status,Address from tbl_employee_master where employee_id=@employee_id;
END
END


GO
/****** Object:  Table [dbo].[tbl_employee_master]    Script Date: 06-08-2020 17:57:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employee_master](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_name] [varchar](50) NULL,
	[father_name] [varchar](50) NULL,
	[mother_name] [varchar](50) NULL,
	[DOB] [date] NULL,
	[gender] [int] NULL,
	[marital_status] [int] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_employee_master] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1. male 2. female' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_employee_master', @level2type=N'COLUMN',@level2name=N'gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.married 2.unmarried' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_employee_master', @level2type=N'COLUMN',@level2name=N'marital_status'
GO
