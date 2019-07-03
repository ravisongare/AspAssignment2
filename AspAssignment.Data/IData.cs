using AspAssignment.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAssignment.Data
{
    public interface IData
    {
        void AddPost(Post post);
        IEnumerable<Post> GetAllPost();
        void AddComment(Comment comment);
        void AddLike(int id);
        IEnumerable<Comment> GetAllComment();
        IEnumerable<Comment> GetComment(int id);
        IEnumerable<User>GetAllUser();
        void AddUser(User user);
        User GetUser(int id);
        Post GetPost(int id);
        void commit();
    }
}
