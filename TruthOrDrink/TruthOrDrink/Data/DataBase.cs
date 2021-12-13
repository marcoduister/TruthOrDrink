using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using TruthOrDrink.Model;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace TruthOrDrink.Data
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection _dataBase;
        public DataBase(string dbpath)
        {
            _dataBase = new SQLiteAsyncConnection(dbpath);
            _dataBase.CreateTableAsync<User>();
            _dataBase.CreateTableAsync<Category>();
            _dataBase.CreateTableAsync<Question>();
            _dataBase.CreateTableAsync<Scoreboard>();
            _dataBase.CreateTableAsync<Game>();
            _dataBase.CreateTableAsync<Player>();
        }

        #region Categories

        public Task<List<Category>> GetCategoryAllByUserIdAsync(int UserId)
        {
            return _dataBase.Table<Category>().Where(e => e.Userid == UserId).ToListAsync();
        }
        public Task<Category> GetCategorybyIdAsync(int Id)
        {
            return _dataBase.Table<Category>().FirstAsync(e => e.Id == Id);
        }
        public Task<int> InsertCategoryAsync(Category category)
        {
            return _dataBase.InsertAsync(category);
        }
        public Task<int> UpdateCategoryAsync(Category category)
        {
            return _dataBase.UpdateAsync(category);
        }

        public Task<int> DeleteCategoryAsync(Category category)
        {
            return _dataBase.DeleteAsync(category);
        }

        #endregion

        #region Questions

        public Task<List<Question>> GetQuestionAllbyIdAsync(int Id)
        {
            return _dataBase.Table<Question>().Where(e=>e.Categoryid ==Id).ToListAsync();
        }
        public Task<Question> GetQuestionbyIdAsync(int Id)
        {
            return _dataBase.Table<Question>().FirstAsync(e => e.Id == Id);
        }

        public Task<int> InsertQuestionAsync(Question question)
        {
            return _dataBase.InsertAsync(question);
        }
        public Task<List<Question>> GetQuestionsAsync()
        {
            return _dataBase.Table<Question>().ToListAsync();
        }

        public Task<int> UpdateQuestionAsync(Question question)
        {
            return _dataBase.UpdateAsync(question);
        }
        public Task<int> DeleteQuestionAsync(Question question)
        {
            return _dataBase.DeleteAsync(question);
        }

        #endregion

        #region Player

        public Task<int> InsertPlayers(Player newPlayer)
        {
            return _dataBase.InsertAsync(newPlayer);
        }

        public Task<List<Player>> GetPlayersByGameIdAsync(int GameId)
        {
            return _dataBase.Table<Player>().Where(e => e.Gameid == GameId).ToListAsync();
        }
        public Task<int> DeletePlayers(Player Player)
        {
            return _dataBase.DeleteAsync(Player);
        }

        #endregion

        #region Game

        public Task<int> CreateGame(Game gameplay)
        {
            return _dataBase.InsertAsync(gameplay);
        }

        public Task<Game> GetGameWithChilde(int GameId)
        {
            return _dataBase.GetWithChildrenAsync<Game>(GameId);
        }

        public Task<List<Game>> GetAllGames(int UserId)
        {
            return _dataBase.Table<Game>().Where(e => e.Userid == UserId).ToListAsync();
        }

        public Task<int> DeleteGame(Game game)
        {
            return _dataBase.DeleteAsync(game);
        }

        #endregion





        #region User

        public async Task<User> GetUserAsync(string Email, string Password)
        {
            return await _dataBase.Table<User>().FirstOrDefaultAsync(e=>e.Email == Email && e.Password == Password);
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _dataBase.Table<User>().FirstOrDefaultAsync(e => e.Id == Id);
        }

        public Task<int> UpdateUserAsync(User user)
        {
            return _dataBase.UpdateAsync(user);
        }

        public async Task<User>  EmailExistAsync(string Email)
        {
            User ExistingUser = await _dataBase.Table<User>().FirstOrDefaultAsync(e => e.Email == Email);
            return ExistingUser;
        }

        public Task<int> InsertUserAsync(User user)
        {
            return _dataBase.InsertAsync(user);
        }

        #endregion
    }
}
