-- DATABASE CREATION
CREATE DATABASE FinalExerciseKEDIVIM

USE FinalExerciseKEDIVIM

-- TABLES CREATION
CREATE TABLE Users(
	[user_id] int UNIQUE NOT NULL IDENTITY(1, 1),
	[username] VARCHAR(16) UNIQUE NOT NULL,
	[user_password] VARCHAR(24) NOT NULL,
	PRIMARY KEY ([user_id])
);

CREATE TABLE Teachers (
	teacher_id int NOT NULL,
	teacher_firstname VARCHAR(55) NOT NULL,
	teacher_lastname VARCHAR(55) NOT NULL,
	PRIMARY KEY(teacher_id),
	FOREIGN KEY(teacher_id) REFERENCES Users([user_id])
);

CREATE TABLE Students(
	student_id int NOT NULL,
	student_firstname VARCHAR(55) NOT NULL,
	student_lastname VARCHAR(55) NOT NULL,
	PRIMARY KEY(student_id),
	FOREIGN KEY(student_id) REFERENCES Users([user_id])
);

CREATE TABLE Courses (
	course_id int NOT NULL IDENTITY(1, 1),
	course_name VARCHAR(55) NOT NULL,
	course_description VARCHAR(5000) NOT NULL,
	teacher_id int NOT NULL,
	PRIMARY KEY(course_id),
	FOREIGN KEY(teacher_id) REFERENCES Teachers(teacher_id)
);

CREATE TABLE StudentsCourses_JT(
	id int NOT NULL IDENTITY(1, 1),
	student_id int NOT NULL,
	course_id int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(student_id) REFERENCES Students(student_id),
	FOREIGN KEY(course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
);
