BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Themes"
(
"Id" INTEGER NOT NULL UNIQUE,
"ThemeName" VARCHAR(200) NOT NULL,
"CreateDate" DATE,
"ModifierDate" DATE,
PRIMARY KEY("Id" AUTOINCREMENT)
);

CREATE TABLE IF NOT EXISTS "Chapters"
(
"Id" INTEGER NOT NULL UNIQUE,
"ThemeId" INTEGER NOT NULL,
"ChapterName" VARCHAR(200) NOT NULL,
"Description" VARCHAR(200) NOT NULL,
"CreateDate" DATE,
"ModifierDate" DATE,
CONSTRAINT "FK_Themes" FOREIGN KEY("ThemeId") REFERENCES "Themes"("Id"),
PRIMARY KEY("Id" AUTOINCREMENT)
);

INSERT INTO Themes (ThemeName, CreateDate, ModifierDate)
VALUES ('Matematika',DATE(),DATE());
INSERT INTO Themes (ThemeName, CreateDate, ModifierDate)
VALUES ('Bahasa Indonesia',DATE(),DATE());
INSERT INTO Themes (ThemeName, CreateDate, ModifierDate)
VALUES ('Bahasa Inggris',DATE(),DATE());
INSERT INTO Themes (ThemeName, CreateDate, ModifierDate)
VALUES ('IPA',DATE(),DATE());

INSERT INTO Chapters (ThemeId, ChapterName, Description, CreateDate, ModifierDate)
VALUES (1, 'Aljabar', 'Pemahaman tentang variable, koefisien, dan konstanta',DATE(),DATE());
INSERT INTO Chapters (ThemeId, ChapterName, Description, CreateDate, ModifierDate)
VALUES (1, 'Eksponen', 'memahami sifat perpangkatan',DATE(),DATE());
INSERT INTO Chapters (ThemeId, ChapterName, Description, CreateDate, ModifierDate)
VALUES (2, 'Puisi','-',DATE(),DATE());
INSERT INTO Chapters (ThemeId, ChapterName, Description, CreateDate, ModifierDate)
VALUES (2, 'Sinonim dan Antonim','-',DATE(),DATE());
INSERT INTO Chapters (ThemeId, ChapterName, Description, CreateDate, ModifierDate)
VALUES (4, 'Hukum Newton','Memahami 3 hukum Newton dan implementasinya',DATE(),DATE());

COMMIT;

