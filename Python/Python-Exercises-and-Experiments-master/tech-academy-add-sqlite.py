
import sqlite3

rosterValues = (
('Jean-Baptiste Zorg', 'Human', 122),
('Korben Dallas', 'Meat Popsicle', 100),
('Ak\'not', 'Bangalore', -5)
)

with sqlite3.connect(':memory:') as connection:
    c = connection.cursor()

c.executescript("""
DROP TABLE IF EXISTS Roster;
CREATE TABLE Roster(Name TEXT, Species TEXT, IQ INT);
""")
c.executemany("INSERT INTO Roster VALUES(?, ?, ?)",rosterValues)
c.execute("UPDATE Roster SET Species = 'Human' WHERE Name = 'Korben Dallas'")
c.execute("SELECT Name, IQ FROM Roster WHERE Species = 'Human'")
for row in c.fetchall():
    print row

connection.close()





