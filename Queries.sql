CREATE TABLE Videos(
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Title NVARCHAR(100) UNIQUE NOT NULL,
	Link NVARCHAR(300) UNIQUE NOT NULL,
	[Language] NCHAR(2) NOT NULL,
	Difficulty NVARCHAR(9) NOT NULL,
	CreatedBy NVARCHAR(450) NOT NULL,
	CreatedAt DATETIME2 NOT NULL
);

CREATE TABLE Subtitles(
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	VideoId INT FOREIGN KEY REFERENCES Videos(Id) NOT NULL,
	Content NVARCHAR(3000) UNIQUE NOT NULL,
	[Language] NCHAR(2) NOT NULL,
	CreatedBy NVARCHAR(450) NOT NULL,
	CreatedAt DATETIME2 NOT NULL
);

CREATE TABLE Transcriptions(
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	VideoId INT FOREIGN KEY REFERENCES Videos(Id) UNIQUE NOT NULL,
	Content NVARCHAR(3000) UNIQUE NOT NULL,
	[Language] NCHAR(2) NOT NULL,
	CreatedBy NVARCHAR(450) NOT NULL,
	CreatedAt DATETIME2 NOT NULL
);

SELECT v.Id, t.VideoId AS TranscriptionVideoId, s.VideoId AS SubtitleVideoId, Title, Link, Difficulty, v.CreatedBy AS VideoCreatedBy, v.[Language], t.Content AS Transcription, s.Content AS Subtitle
FROM Videos AS v
INNER JOIN Transcriptions AS t ON v.Id = t.VideoId
INNER JOIN Subtitles AS s ON v.Id = s.VideoId;