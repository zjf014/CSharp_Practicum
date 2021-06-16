# C#课程设计示例
## 1.数据库设计
* Student表

sno | sname | ssex | sage | sclass | sgrade | ssubject
--- | ----- | ---- | ---- | ------ | ------ | --------
学号 | 姓名 | 性别 | 年龄 | 班级 | 年级 | 专业

* Teacher表

tno | tname | tage | tsex | ttitle
--- | ----- | ---- | ---- | ------
教工号 | 姓名 | 年龄 | 性别 | 职称

* Course表

cno | cname | credit | teacher 
--- | ----- | ------ | ------- 
课程号 | 课程名称 | 学分 | 任课教师

* Score表

cno | sno | score
--- | --- | ----
课程号 | 学号 | 成绩

* Users表

username | password | type
-------- | -------- | ----
用户名 | 密码 | 登录类型

