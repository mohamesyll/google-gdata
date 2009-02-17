/* Copyright (c) 2006 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/


using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Net; 
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using System.Collections.Generic;

namespace Google.YouTube 
{
    /// <summary>
    /// the Comment entry for a Comments Feed, a feed of Comment for YouTube
    /// </summary>
    public class Comment : Entry
    {
        /// <summary>
        /// creates the inner contact object when needed
        /// </summary>
        /// <returns></returns>
        protected override void EnsureInnerObject()
        {
            if (this.AtomEntry == null)
            {
                this.AtomEntry = new CommentEntry();
            }
        }


    }


    /// <summary>
    /// the subscription entry for a subscriptionfeed Feed
    /// </summary>
    public class Subscription : Entry
    {
         /// <summary>
        /// readonly accessor for the SubscriptionEntry that is underneath this object.
        /// </summary>
        /// <returns></returns>
        public  SubscriptionEntry SubscriptionEntry
        {
            get
            {
                return this.AtomEntry as SubscriptionEntry;
            }
        }

        
        /// <summary>
        /// creates the inner contact object when needed
        /// </summary>
        /// <returns></returns>
        protected override void EnsureInnerObject()
        {
            if (this.AtomEntry == null)
            {
                this.AtomEntry = new SubscriptionEntry();
            }
        }




        /// <summary>
        ///  returns the subscription type
        /// </summary>
        /// <returns></returns>
        public SubscriptionEntry.SubscriptionType Type
        {
            get
            {
                EnsureInnerObject();
                return this.SubscriptionEntry.Type;
            }

            set
            {
                EnsureInnerObject();
                this.SubscriptionEntry.Type = value;
            }
        }


        /// <summary>
        /// The user who is the owner of this subscription
        /// </summary>
        public string UserName 
        {
            get
            {
                EnsureInnerObject();
                return this.SubscriptionEntry.UserName;
            }
            set
            {
                EnsureInnerObject();
                this.SubscriptionEntry.UserName = value;
            }
        }

        /// <summary>
        /// if the subscripiton is a keyword query, this will be the 
        /// subscripted to query term
        /// </summary>
        public string QueryString 
        {
            get
            {
                EnsureInnerObject();
                return this.SubscriptionEntry.QueryString;

            }
            set
            {
                EnsureInnerObject();
                this.SubscriptionEntry.QueryString = value;
            }
        }

        /// <summary>
        /// the id of the playlist you are subscriped to
        /// </summary>
        public string PlaylistId 
        {
            get
            {
                EnsureInnerObject();
                return this.SubscriptionEntry.PlaylistId;

            }
            set
            {
                EnsureInnerObject();
                this.SubscriptionEntry.PlaylistId = value;
            }
        }

        /// <summary>
        /// the human readable name of the playlist you are subscribed to
        /// </summary>
        public string PlaylistTitle
        {
            get
            {
                EnsureInnerObject();
                return this.SubscriptionEntry.PlaylistTitle;

            }
            set
            {
                EnsureInnerObject();
                this.SubscriptionEntry.PlaylistTitle = value;
            }
        }

    }

    /// <summary>
    /// the Activity entry for an Activities Feed, a feed of activities for the friends/contacts
    /// of the logged in user
    /// </summary>
    /// <returns></returns>
    public class Activity : Entry
    {


        /// <summary>
        /// creates the inner contact object when needed
        /// </summary>
        /// <returns></returns>
        protected override void EnsureInnerObject()
        {
            if (this.AtomEntry == null)
            {
                this.AtomEntry = new ActivityEntry();
            }
        }

        /// <summary>
        /// readonly accessor for the YouTubeEntry that is underneath this object.
        /// </summary>
        /// <returns></returns>
        public  ActivityEntry ActivityEntry
        {
            get
            {
                return this.AtomEntry as ActivityEntry;
            }
        }


        /// <summary>
        /// specifies a unique ID that YouTube uses to identify a video.
        /// </summary>
        /// <returns></returns>
        public string VideoId
        {
            get
            {
                EnsureInnerObject();
                if (this.ActivityEntry.VideoId != null)
                {
                    return this.ActivityEntry.VideoId.Value;
                }
                return null; 
            }
        }

        public ActivityType Type
        {
            get
            {
                EnsureInnerObject();
                return this.ActivityEntry.Type;
            }
        }
    }

     /// <summary>
    /// the Playlist entry for a Playlist Feed, a feed of Playlist for YouTube
    /// </summary>
    public class Playlist : Entry
    {

        /// <summary>
        /// creates the inner contact object when needed
        /// </summary>
        /// <returns></returns>
        protected override void EnsureInnerObject()
        {
            if (this.AtomEntry == null)
            {
                this.AtomEntry = new PlaylistsEntry();
            }
        }

        /// <summary>
        /// returns the internal atomentry as a PlayListsEntry
        /// </summary>
        /// <returns></returns>
        public PlaylistsEntry PlaylistsEntry
        {
            get
            {
                return this.AtomEntry as PlaylistsEntry;
            }
        }

        /// <summary>
        /// specifies the number of entries in a playlist feed. This tag appears in the entries in a 
        /// playlists feed, where each entry contains information about a single playlist.
        /// </summary>
        /// <returns></returns>
        public int CountHint
        {
            get 
            {
                EnsureInnerObject();
                return this.PlaylistsEntry.CountHint;
            }
        }
    }


    //////////////////////////////////////////////////////////////////////
    /// <summary>the Video Entry in feed&lt;Videos&gt; for YouTube
    /// </summary> 
    //////////////////////////////////////////////////////////////////////
    public class Video : Entry
    {
        

        /// <summary>
        /// creates the inner contact object when needed
        /// </summary>
        /// <returns></returns>
        protected override void EnsureInnerObject()
        {
            if (this.AtomEntry == null)
            {
                this.AtomEntry = new YouTubeEntry();
            }
        }


        /// <summary>
        /// readonly accessor for the YouTubeEntry that is underneath this object.
        /// </summary>
        /// <returns></returns>
        public  YouTubeEntry YouTubeEntry
        {
            get
            {
                return this.AtomEntry as YouTubeEntry;
            }
        }

        /// <summary>
        /// specifies a unique ID that YouTube uses to identify a video.
        /// </summary>
        /// <returns></returns>
        public string VideoId
        {
            get
            {
                EnsureInnerObject();
                return this.YouTubeEntry.VideoId;
            }
        }

        /// <summary>
        /// contains a summary or description of a video. This field is required in requests to 
        /// upload or update a video's metadata. The description should be sentence-based, 
        /// rather than a list of keywords, and may be displayed in search results. The description has a 
        /// maximum length of 5000 characters and may contain all valid UTF-8 characters except &lt; and &gt; 
        /// </summary>
        /// <returns></returns>
        public string Description
        {
            get
            {
                if (this.YouTubeEntry != null && 
                    this.YouTubeEntry.Media != null &&
                    this.YouTubeEntry.Media.Description != null)
                {
                    return this.YouTubeEntry.Media.Description.Value;
                }
                return null; 
            }
            set
            {
                EnsureInnerObject();
                if (this.YouTubeEntry.Media == null)
                {
                    this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                }
                if (this.YouTubeEntry.Media.Description == null)
                {
                    this.YouTubeEntry.Media.Description = new MediaDescription();
                }
                this.YouTubeEntry.Media.Description.Value = value; 
            }
        }


        /// <summary>
        /// the title of the Video. Overloaded to keep entry.title and the media.title 
        ///  in sync. 
        /// </summary>
        /// <returns></returns>
        public override string Title
        {
            get
            {
                return base.Title;
            }
            set
            {
                base.Title = value;
                EnsureInnerObject();
                if (this.YouTubeEntry.Media == null)
                {
                    this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                }
                if (this.YouTubeEntry.Media.Title == null)
                {
                    this.YouTubeEntry.Media.Title = new MediaTitle();
                }
                this.YouTubeEntry.Media.Title.Value = value; 
            }
        }


        /// <summary>
        /// returns the categories for the video
        /// </summary>
        /// <returns></returns>
        public ExtensionCollection<MediaCategory> Tags
        {
            get
            {
                EnsureInnerObject();
                if (this.YouTubeEntry.Media == null)
                {
                    this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                }
                return this.YouTubeEntry.Media.Categories; 
            }
        }

        /// <summary>
        /// returns the keywords for the video, see MediaKeywords for more
        /// </summary>
        /// <returns></returns>
        public string Keywords
        {
            get
            {
                if (this.YouTubeEntry != null)
                {
                    if (this.YouTubeEntry.Media != null)
                    {
                        if (this.YouTubeEntry.Media.Keywords != null)
                        {
                            return this.YouTubeEntry.Media.Keywords.Value;
                        }
                    }
                }
                return null;
            }
            set
            {
                EnsureInnerObject();
                if (this.YouTubeEntry.Media == null)
                {
                    this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                }
                if (this.YouTubeEntry.Media.Keywords == null)
                {
                    this.YouTubeEntry.Media.Keywords = new MediaKeywords();
                }
                this.YouTubeEntry.Media.Keywords.Value = value; 
            }
        }


        /// <summary>
        /// returns the collection of thumbnails for the vido
        /// </summary>
        /// <returns></returns>
        public ExtensionCollection<MediaThumbnail> Thumbnails
        {
            get
            {
                if (this.YouTubeEntry != null)
                {
                    if (this.YouTubeEntry.Media == null)
                    {
                        this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                    }
                    return this.YouTubeEntry.Media.Thumbnails; 
                }
                return null;
            }
        }

        /// <summary>
        /// specifies a URL where the full-length video is available through a media player that runs 
        /// inside a web browser. In a YouTube Data API response, this specifies the URL for the page 
        /// on YouTube's website that plays the video
        /// </summary>
        /// <returns></returns>
        public Uri WatchPage
        {
            get
            {
                if (this.YouTubeEntry!= null  && 
                    this.YouTubeEntry.Media != null  && 
                    this.YouTubeEntry.Media.Player != null )
                {
                    return new Uri(this.YouTubeEntry.Media.Player.Url);
                }
                return null; 
            }
        }

        /// <summary>
        /// identifies the owner of a video.
        /// </summary>
        /// <returns></returns>
        public string Uploader
        {
            get
            {
                if (this.YouTubeEntry!= null  && 
                    this.YouTubeEntry.Media != null  && 
                    this.YouTubeEntry.Media.Credit != null )
                {
                    return this.YouTubeEntry.Media.Credit.Value;
                }
                return null; 
            }
            set
            {
                EnsureInnerObject();
                if (this.YouTubeEntry.Media == null)
                {
                    this.YouTubeEntry.Media = new Google.GData.YouTube.MediaGroup();
                }
                if (this.YouTubeEntry.Media.Credit == null)
                {
                    this.YouTubeEntry.Media.Credit = new Google.GData.YouTube.MediaCredit();
                }
                this.YouTubeEntry.Media.Credit.Value = value; 
            }
        }


        /// <summary>
        /// returns the viewcount for the video
        /// </summary>
        /// <returns></returns>
        public int ViewCount
        {
            get
            {
                if (this.YouTubeEntry != null && this.YouTubeEntry.Statistics != null)
                    return Int32.Parse(this.YouTubeEntry.Statistics.ViewCount);
                return 0;
            }
        }

        /// <summary>
        /// returns the number of comments for the video
        /// </summary>
        /// <returns></returns>
        public int CommmentCount
        {
            get
            {
                if (this.YouTubeEntry != null && 
                    this.YouTubeEntry.Comments != null &&
                    this.YouTubeEntry.Comments.FeedLink != null)
                {
                        return this.YouTubeEntry.Comments.FeedLink.CountHint;
                }
                return 0;
            }
        }

        /// <summary>
        /// returns the rating average for a video
        /// </summary>
        /// <returns></returns>
        public double Rating
        {
            get
            {
                if (this.YouTubeEntry != null &&
                    this.YouTubeEntry.Rating != null)
                {
                    return this.YouTubeEntry.Rating.Average;
                }
                return 0;
            }
        }
    }


    /// <summary>
    /// YouTube specific class for request settings,
    /// adds support for developer key and clientid
    /// </summary>
    /// <returns></returns>
    public class YouTubeRequestSettings : RequestSettings
    {
        private string clientID;
        private string developerKey;

        /// <summary>
        /// A constructor for a readonly scenario.
        /// </summary>
        /// <param name="applicationName">The name of the application</param>
        /// <param name="client">the client ID to use</param>
        /// <param name="developerKey">the developer key to use</param>
        /// <returns></returns>
        public YouTubeRequestSettings(string applicationName, string client, string developerKey) : base(applicationName)
        {
            this.clientID = client;
            this.developerKey = developerKey;
        }

        /// <summary>
        /// A constructor for a client login scenario
        /// </summary>
        /// <param name="applicationName">The name of the application</param>
        /// <param name="client">the client ID to use</param>
        /// <param name="developerKey">the developer key to use</param>
        /// <param name="userName">the username</param>
        /// <param name="passWord">the password</param>
        /// <returns></returns>
        public YouTubeRequestSettings(string applicationName, string client, string developerKey, string userName, string passWord)  
                    : base(applicationName, userName, passWord)
        {
            this.clientID = client;
            this.developerKey = developerKey;
        }

        /// <summary>
        /// a constructor for a web application authentication scenario        
        /// </summary>
        /// <param name="applicationName">The name of the application</param>
        /// <param name="client">the client ID to use</param>
        /// <param name="developerKey">the developer key to use</param>
        /// <param name="authSubToken">the authentication token</param>
        /// <returns></returns>
        public YouTubeRequestSettings(string applicationName, string client, string developerKey, string authSubToken)  
                    : base(applicationName, authSubToken)
        {
            this.clientID = client;
            this.developerKey = developerKey;
        }

        /// <summary>
        /// returns the client ID
        /// </summary>
        /// <returns></returns>
        public string Client
        {
            get
            {
                return this.clientID;
            }
        }

        /// <summary>
        /// returns the developer key
        /// </summary>
        /// <returns></returns>
        public string DeveloperKey
        {
            get
            {
                return this.developerKey;
            }
        }
    }




    //////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The YouTube Data API allows applications to perform functions normally 
    /// executed on the YouTube website. The API enables your application to search 
    /// for YouTube videos and to retrieve standard video feeds, comments and video
    /// responses. 
    /// In addition, the API lets your application upload videos to YouTube or 
    /// update existing videos. Your can also retrieve playlists, subscriptions, 
    /// user profiles and more. Finally, your application can submit 
    /// authenticated requests to enable users to create playlists, 
    /// subscriptions, contacts and other account-specific entities.
    /// </summary>
    ///  <example>
    ///         The following code illustrates a possible use of   
    ///          the <c>YouTubeRequest</c> object:  
    ///          <code>    
    ///           YouTubeRequestSettings settings = new YouTubeRequestSettings("yourApp", "yourClient", "yourKey");
    ///            settings.PageSize = 50; 
    ///            settings.AutoPaging = true;
    ///             YouTubeRequest f = new YouTubeRequest(settings);
    ///         Feed<Video> feed = f.GetStandardFeed(YouTubeQuery.MostPopular);
    ///     
    ///         foreach (Video v in feed.Entries)
    ///         {
    ///             Feed<Comment> list= f.GetComments(v);
    ///             foreach (Comment c in list.Entries)
    ///             {
    ///                 Console.WriteLine(c.Title);
    ///             }
    ///         }
    ///  </code>
    ///  </example>
    //////////////////////////////////////////////////////////////////////
    public class YouTubeRequest : FeedRequest<YouTubeService>
    {

        /// <summary>
        /// default constructor for a YouTubeRequest
        /// </summary>
        /// <param name="settings"></param>
        public YouTubeRequest(YouTubeRequestSettings settings) : base(settings)
        {
            if (settings.Client != null && settings.DeveloperKey != null)
            {
                this.Service = new YouTubeService(settings.Application, settings.Client, settings.DeveloperKey);
            }
            else
            {
                this.Service = new YouTubeService(settings.Application);
            }

            PrepareService();
        }

        /// <summary>
        /// returns a Feed of vidoes for a given username
        /// </summary>
        /// <param name="user">the username</param>
        /// <returns>a feed of Videos</returns>
        public Feed<Video> GetVideoFeed(string user)
        {
            YouTubeQuery q = PrepareQuery<YouTubeQuery>(YouTubeQuery.CreateUserUri(user));
            return PrepareFeed<Video>(q); 
        }

         /// <summary>
        ///  returns one of the youtube default feeds. 
        /// </summary>
        /// <param name="feedspec">the string representation of the URI to use</param>
        /// <returns>a feed of Videos</returns>
        public Feed<Video> GetStandardFeed(string feedspec)
        {
            YouTubeQuery q = PrepareQuery<YouTubeQuery>(feedspec);
            return PrepareFeed<Video>(q); 
        }

        /// <summary>
        /// returns a Feed of favorite videos for a given username
        /// </summary>
        /// <param name="user">the username</param>
        /// <returns>a feed of Videos</returns>
        public Feed<Video> GetFavoriteFeed(string user)
        {
            YouTubeQuery q = PrepareQuery<YouTubeQuery>(YouTubeQuery.CreateFavoritesUri(user));
            return PrepareFeed<Video>(q); 
        }

        /// <summary>
        /// returns a Feed of subscriptions for a given username
        /// </summary>
        /// <param name="user">the username</param>
        /// <returns>a feed of Videos</returns>
        public Feed<Subscription> GetSubscriptionsFeed(string user)
        {
            YouTubeQuery q = PrepareQuery<YouTubeQuery>(YouTubeQuery.CreateSubscriptionUri(user));
            return PrepareFeed<Subscription>(q); 
        }

        /// <summary>
        /// returns a Feed of playlists  for a given username
        /// </summary>
        /// <param name="user">the username</param>
        /// <returns>a feed of Videos</returns>
        public Feed<Playlist> GetPlaylistsFeed(string user)
        {
            YouTubeQuery q = PrepareQuery<YouTubeQuery>(YouTubeQuery.CreatePlaylistsUri(user));
            return PrepareFeed<Playlist>(q);             
        }

        /// <summary>
        /// returns the related videos for a given video
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Feed<Video> GetRelatedVideos(Video v)
        {
            if (v.YouTubeEntry != null)
            {
                if (v.YouTubeEntry.RelatedVideosUri != null)
                {
                    YouTubeQuery q = PrepareQuery<YouTubeQuery>(v.YouTubeEntry.RelatedVideosUri.ToString());
                    return PrepareFeed<Video>(q); 
                }
            }
            return null;
        }

        /// <summary>
        ///  gets the response videos for a given video
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Feed<Video> GetResponseVideos(Video v)
        {
            if (v.YouTubeEntry != null)
            {
                if (v.YouTubeEntry.VideoResponsesUri != null)
                {
                    YouTubeQuery q = PrepareQuery<YouTubeQuery>(v.YouTubeEntry.VideoResponsesUri.ToString());
                    return PrepareFeed<Video>(q); 
                }
            }
            return null;
        }

        /// <summary>
        /// get's the comments for a given video
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Feed<Comment> GetComments(Video v)
        {
             if (v.YouTubeEntry != null && 
                    v.YouTubeEntry.Comments != null && 
                    v.YouTubeEntry.Comments.FeedLink != null && 
                    v.YouTubeEntry.Comments.FeedLink.Href != null
                    )
             {
                    YouTubeQuery q = PrepareQuery<YouTubeQuery>(v.YouTubeEntry.Comments.FeedLink.Href);
                    return PrepareFeed<Comment>(q); 
             }
             return new Feed<Comment>(null);
        }


        /// <summary>
        /// get's the activities that your contacts/friends did recently 
        /// </summary>
        /// <returns></returns>
        public Feed<Activity> GetActivities()
        {
            return GetActivities(DateTime.MinValue);
        }

        
        /// <summary>
        /// get's the activities for the set of users you pass in
        /// </summary>
        /// <param name="youTubeUsers">The list of youtube user ids to use</param>
        /// <returns></returns>
        public Feed<Activity> GetActivities(List<string> youTubeUsers)
        {
            return GetActivities(youTubeUsers, DateTime.MinValue);
        }

        /// <summary>
        /// get's the activities for the set of users you pass in
        /// </summary>
        /// <param name="youTubeUsers">The list of youtube user ids to use</param>
        /// <returns></returns>
        public Feed<Activity> GetActivities(List<string> youTubeUsers, DateTime since)
        {
            if (this.Settings != null)
            {
                UserActivitiesQuery q = new UserActivitiesQuery();
                q.ModifiedSince = since;
                q.Authors = youTubeUsers;
                PrepareQuery(q);
                return PrepareFeed<Activity>(q);             
            }
            return new Feed<Activity>(null);
        }

        /// <summary>
        /// get's the activities that your contacts/friends did recently, from the 
        /// given datetime point
        /// </summary>
        /// <returns></returns>
        public Feed<Activity> GetActivities(DateTime since)
        {
            if (this.Settings != null)
            {
                ActivitiesQuery q = new ActivitiesQuery();
                q.ModifiedSince = since; 
                PrepareQuery(q);
                return PrepareFeed<Activity>(q);             
            }
            return new Feed<Activity>(null);
        }



        /** 
           <summary>
            returns the feed of videos for a given playlist
           </summary>
            <example>
                The following code illustrates a possible use of   
                the <c>GetPlaylist</c> method:  
                <code>    
                  YouTubeRequestSettings settings = new YouTubeRequestSettings("yourApp", "yourClient", "yourKey", "username", "pwd");
                  YouTubeRequest f = new YouTubeRequest(settings);
                  Feed&lt;Playlist&gt; feed = f.GetPlaylistsFeed(null);
                </code>
            </example>
            <param name="p">the playlist to get the videos for</param>
            <returns></returns>
        */
        public Feed<Video> GetPlaylist(Playlist p)
        {
            if (p.AtomEntry != null && 
                p.AtomEntry.Content != null && 
                p.AtomEntry.Content.AbsoluteUri != null)
            {
                   YouTubeQuery q = PrepareQuery<YouTubeQuery>(p.AtomEntry.Content.AbsoluteUri);
                   return PrepareFeed<Video>(q); 
            }
            return new Feed<Video>(null);
        }



        /// <summary>
        /// uploads or inserts a new video for a given user.
        /// </summary>
        /// <param name="userName">if this is null the default authenticated user will be used</param>
        /// <param name="v">the created video to be used</param>
        /// <returns></returns>
        public Video Upload(string userName, Video v)
        {
            Video rv = null;
            YouTubeEntry e = this.Service.Upload(v.YouTubeEntry);
            if (e != null)
            {
                rv= new Video();
                rv.AtomEntry = e; 
            }
            return rv; 
        }


        /// <summary>
        /// returns the video this activity was related to
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public Video GetVideoForActivity(Activity activity)
        {
            Video rv = null;

            if (activity.ActivityEntry != null)
            {
                AtomUri address = activity.ActivityEntry.VideoLink;
                YouTubeQuery q = PrepareQuery<YouTubeQuery>(address.ToString());
                YouTubeFeed f = this.Service.Query(q);

                if (f != null && f.Entries.Count > 0)
                {
                    rv = new Video();
                    rv.AtomEntry = f.Entries[0];
                }
            }

            return rv;
        }




    }
}