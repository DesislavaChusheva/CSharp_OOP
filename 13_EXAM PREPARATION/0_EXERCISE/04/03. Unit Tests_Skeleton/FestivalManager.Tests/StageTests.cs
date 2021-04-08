// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        Song song;
        Performer performer;
        Stage stage;

        [SetUp]
        public void SetUp()
        {
            song = new Song("Song", new TimeSpan(00, 03, 20));
            performer = new Performer("FirstName", "LastName", 20);
            stage = new Stage();
        }
        [Test]
        public void PerformerConstructor()
        {
            performer = new Performer("FirstName", "LastName", 20);
            Assert.AreNotEqual(performer.SongList, null);
        }
        [Test]
        public void StageConstructor()
        {
            stage = new Stage();
            Assert.AreNotEqual(stage.Performers, null);
        }
        [Test]
        public void Performer_ToString()
        {
            string exp = "FirstName LastName";
            Assert.AreEqual(performer.ToString(), exp);
        }
        [Test]
        public void Song_ToString()
        {
            string exp = $"Song (03:20)";
            Assert.AreEqual(song.ToString(), exp);
        }
        [Test]
        public void Stage_AddPerformer_ThrowsEx_Validator()
        {
            performer = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'performer')");
        }
        [Test]
        public void Stage_AddPerformer_ThrowsEx_SmallAge()
        {
            performer = new Performer("First", "Last", 5);
            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
            Assert.AreEqual(ex.Message, "You can only add performers that are at least 18.");
        }
        [Test]
        public void Stage_AddPerformer_Working()
        {
            stage.AddPerformer(performer);
            Assert.AreEqual(stage.Performers.Count, 1);
        }
        [Test]
        public void Stage_AddSong_ThrowsEx_Validator()
        {
            song = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'song')");
        }
        [Test]
        public void Stage_AddSong_ThrowsEx_ShortSonge()
        {
            song = new Song("Song", new TimeSpan(00, 00, 20));
            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddSong(song));
            Assert.AreEqual(ex.Message, "You can only add songs that are longer than 1 minute.");
        }
        [Test]
        public void AddSongToPerformer_ThrowsEx_PerformerNull()
        {
            stage.AddSong(song);
            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, performer.FullName));
            Assert.AreEqual(ex.Message, "There is no performer with this name.");
        }
        [Test]
        public void AddSongToPerformer_ThrowsEx_SongNull()
        {
            stage.AddPerformer(performer);
            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, performer.FullName));
            Assert.AreEqual(ex.Message, "There is no song with this name.");
        }
        [Test]
        public void AddSongToPerformer_Working()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string exp = $"{song} will be performed by {performer}";
            Assert.AreEqual(stage.AddSongToPerformer(song.Name, performer.FullName), exp);
        }
        [Test]
        public void Play_Working()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);
            Assert.AreEqual(stage.Play(), "1 performers played 1 songs");
        }
    }
}