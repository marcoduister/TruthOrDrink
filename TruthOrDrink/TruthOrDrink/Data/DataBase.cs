using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using TruthOrDrink.Model;
using System.Threading.Tasks;

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

        public Task<List<Category>> GetCategoryAllAsync()
        {
            return _dataBase.Table<Category>().ToListAsync();
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

        public Task<List<Question>> GetQuestionAllAsync()
        {
            return _dataBase.Table<Question>().ToListAsync();
        }
        public Task<Question> GetQuestionbyIdAsync(int Id)
        {
            return _dataBase.Table<Question>().FirstAsync(e => e.Id == Id);
        }
        public Task<int> InsertQuestionAsync(Question question)
        {
            return _dataBase.InsertAsync(question);
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





        public Task<List<Question>> GetQuestionsAsync()
        {
            return _dataBase.Table<Question>().ToListAsync();
        }
        public Task<List<Player>> GetPlayersAsync()
        {
            return _dataBase.Table<Player>().ToListAsync();
        }
        public async Task<User> GetUserAsync(string Email, string Password)
        {
            return await _dataBase.Table<User>().FirstOrDefaultAsync(e=>e.Email == Email && e.Password == Password);
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
    }
}
