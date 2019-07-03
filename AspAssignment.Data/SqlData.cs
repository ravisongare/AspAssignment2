using AspAssignment.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspAssignment.Data
{
   public class SqlData :IData
    {
        private readonly AspAssignmentDbContext db;

        public SqlData(AspAssignmentDbContext db)
        {
            this.db = db;
        }

        public void AddPost(Post post)
        {
            
            db.Posts.Add(post);
        }

        public void AddComment(Comment comment)
        {
            db.comments.Add(comment);
        }

        public void AddLike(int id)
        {
           var temp = db.Posts.Single(r => r.ID == id);
            temp.Likes = temp.Likes + 1;
            
            
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
        }

        public void commit()
        {
            db.SaveChanges();
        }

        public IEnumerable<Post> GetAllPost()
        {
            return db.Posts;              
        }

        public IEnumerable<User> GetAllUser()
        {
            return db.Users;
        }

        public IEnumerable<Comment> GetComment(int id)
        {

            return db.comments.Where(r => r.PostId == id);
        }

        public Post GetPost(int id)
        {
            return db.Posts.Single(r => r.ID== id);
        }

        public User GetUser(int id)
        {
            return db.Users.Single(r => r.Id == id);
        }

        public IEnumerable<Comment> GetAllComment()
        {
            return db.comments;
        }
    }
}
