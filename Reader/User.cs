using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reader
{
    public class User
    {
        private int _id;
        private string _name;
        private string _userName;
        private string _email;
        private string _pass;
        private string _prof;
        private string _bio;
        private string _picPath;

        public User(int id, string name, string uname, string email, string pass, string prof, string bio, string path)
        {
            _id = id;
            _name = name;
            _userName = uname;
            _email = email;
            _pass = pass;
            _prof = prof;
            _bio = bio;
            _picPath = path;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name 
        {
            get
            {
                return _name;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
        }

        public string Profession
        {
            get
            {
                return _prof;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public string Bio
        {
            get
            {
                return _bio;
            }
        }

        public string PicPath
        {
            get
            {
                return _picPath;
            }
        }
    }
}