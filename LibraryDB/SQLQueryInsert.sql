
IF NOT EXISTS(SELECT * FROM Users WHERE FirstName='Anna' and LastName = 'Avramenko')
BEGIN
INSERT INTO USERS  (FirstName, LastName, PhoneNumber)
   VALUES ('Anna','Avramenko','0934565789'), 
          ('Daria','Prokopovych','0934556789'), 
          ('Olena','Rehush','0987665789'), 
          ('Roman','Ivashkovych','0934008789'),
      ('Ihor','Kyluk','0967087891'),
      ('Oleh','Shevchenko','0967808789'),
      ('Oksana','Malyarenko','0987809909'),
      ('Taras','Dovbush','09344658789'),
      ('Olya','Romanenko','0987808789'),
      ('Sofia','Banaschuk','09387898789');
 END

IF NOT EXISTS(SELECT * FROM Books WHERE Name = 'Lord of the rings')
BEGIN
   INSERT INTO Books  (Name, Author, ISBN, Genre, Year)
   VALUES ('Lord of the rings','R.R.Tolkien','966-8657-18-7','fantasy', '2006'), 
   ('The girl on the train','P.Hawkins','978-617-12-1533-7','detective', '2016'), 
   ('The Murder at the Vicarage','A.Christie','978-617-12-4110-7','detective', '2017'), 
   ('Solaris','S.Lem','978-966-10-2118-0','fantasy', '2016'), 
   ('Dandelion Wine','R.Bradbury','966-8657-25-7','fantasy', '2016'), 
   ('The Shining','S.King','978-9661-46-7','mystical', '2014'),
   ('His dark matirials','P.Pullman','978-9663-43-7','fantasy', '2007'),
   ('Shindlers list','T.Keneally','978-9654-43-7','historical', '2015'),
   ('Mr Penumbras 24-Hour Bookstore','R.Sloan','978-9809-43-7','fantasy', '2017'),
   ('Neverending story','M.Ende','978-9688-43-7','fantasy', '2014');
   END
