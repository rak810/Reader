using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reader
{
    public class Article
    {
        private int _id;
        private int _authorId;
        private int _likes;
        private string _title;
        private string _summary;
        private string _body;
        private string _tags;
        private DateTime _publishTime;

        public Article(int id, int authId, int likes, string title, string summary, string body, string tags, DateTime pubTime)
        {
            _id = id;
            _authorId = authId;
            _likes = likes;
            _title = title;
            _summary = summary;
            _body = body;
            _tags = tags;
            _publishTime = pubTime;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public int AuthorId
        {
            get
            {
                return _authorId;
            }
        }

        public int Likes
        {
            get
            {
                return _likes;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
        }

        public string Tags
        {
            get
            {
                return _tags;
            }
        }

        public DateTime PublishedAt
        {
            get
            {
                return _publishTime;
            }
        }
    }
}