using System;
using TheCore.Interfaces;

namespace TheCore.Helpers
{
    public class LinkBuilder
    {
        private string DefaultTicketStubImageLocation = "~/images/TicketStubs/";

        public string YafTopicLink(int topicId)
        {
            return string.Format("/Default.aspx?g=posts&t={0}", topicId.ToString());
        }

        public string YafPostLink(int postId)
        {
            string link = string.Empty;
            //NEEDS IMPLEMENTATION
            ///YAF/default.aspx?g=posts&m=2#post2
            return link;

        }

        public string GetShowImageLocationLink(string fileName, string defaultShowImageLocation)
        {
            return string.Format("{0}{1}", defaultShowImageLocation, fileName);
        }

        public string GetImageLinkByFileName(string fileName)
        {
            return string.Format("~/images/Shows/{0}", fileName);
        }

        public string GetTicketStubLink(string fileName)
        {
            return string.Format("{0}{1}", DefaultTicketStubImageLocation, fileName);
        }

        public string ContactUsLink()
        {
            return "/AboutUs.aspx";
        }

        #region MyPhishMarket Links

        public string DashboardLink()
        {
            return "/MyPhishMarket/Dashboard.aspx";
        }

        public string MyPicturesByShowLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/MyPicturesByShow.aspx?id={0}", showId.ToString());
        }

        public string AddPhotoLink()
        {
            return AddPhotoLink(null);
        }

        public string AddPhotoLink(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return "/MyPhishMarket/AddPhoto.aspx";
            }
            else
            {
                return string.Format("/MyPhishMarket/AddPhoto.aspx?returnUrl={0}", returnUrl);
            }

        }

        public string AddPhotoLink(Guid showId, PhotoType type, string returnUrl)
        {
            return string.Format("/MyPhishMarket/AddPhoto.aspx?showId={0}&type={1}&returnUrl={2}", showId, (int)type, returnUrl);
        }

        //public string AddPhotoLink(Guid showId, PhotoType type)
        //{
        //    return string.Format("/MyPhishMarket/AddPhoto.aspx?showId={0}&type={1}", showId, (int)type);
        //}

        public string ChangeProfileLink()
        {
            return "/MyPhishMarket/Profile/ChangeProfile.aspx";
        }

        public string ProfileStep1Link()
        {
            return "/MyPhishMarket/Profile/Step1.aspx";
        }

        public string ProfileStep2Link()
        {
            return "/MyPhishMarket/Profile/Step2.aspx";
        }

        public string ProfileStep3Link()
        {
            return "/MyPhishMarket/Profile/Step3.aspx";
        }

        public string EditPosterLink(Guid posterId)
        {
            return string.Format("/MyPhishMarket/EditPoster.aspx?id={0}", posterId);
        }

        public string EditTicketStubLink(Guid ticketStubId)
        {
            return string.Format("/MyPhishMarket/EditTicketStub.aspx?id={0}", ticketStubId);
        }

        public string EditArtLink(Guid artId)
        {
            return string.Format("/MyPhishMarket/EditArt.aspx?id={0}", artId);
        }

        public string MyTicketStubsLink()
        {
            return "/MyPhishMarket/MyTicketStubs.aspx";
        }

        public string MyTicketStubsLink(string showId)
        {
            return string.Format("/MyPhishMarket/MyTicketStubs.aspx?showId={0}", showId);
        }

        public string MyTicketStubsLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/MyTicketStubs.aspx?showId={0}", showId);
        }

        public string MyPostersLink()
        {
            return "/MyPhishMarket/MyPosters.aspx";
        }

        public string MyPostersLink(string showId)
        {
            return string.Format("/MyPhishMarket/MyPosters.aspx?showId={0}", showId);
        }

        public string MyPostersLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/MyPosters.aspx?showId={0}", showId);
        }

        public string MyPicturesLink()
        {
            return "/MyPhishMarket/MyPictures.aspx";
        }

        public string MyPicturesLink(string showId)
        {
            return string.Format("/MyPhishMarket/MyPictures.aspx?showId={0}", showId);
        }

        public string MyPicturesLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/MyPictures.aspx?showId={0}", showId);
        }

        public string FindForShowLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/FindForShow.aspx?showId={0}", showId);
        }

        public string AddMyShowLink()
        {
            return "/MyPhishMarket/AddMyShow.aspx";
        }

        public string AddMyShowLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/AddMyShow.aspx?showId={0}", showId);
        }

        public string AnalysisLink(Guid showId)
        {
            return string.Format("/MyPhishMarket/ShowAnalysis.aspx?showId={0}", showId);
        }

        public string AnalysisLink(Guid showId, Guid myShowId)
        {
            return string.Format("/MyPhishMarket/ShowAnalysis.aspx?showId={0}&myShowId={1}", showId, myShowId);
        }

        public string ViewProfileLink(Guid userId)
        {
            return string.Format("/MyPhishMarket/ViewProfile.aspx?userId={0}", userId);
        }

        public string ViewFullShowReviewLink(Guid myShowId)
        {
            return string.Format("/MyPhishMarket/FullShowReview.aspx?myShowId={0}", myShowId);
        }

        public string ReviewsLink()
        {
            return "/Reviews.aspx";
        }

        public string ShowReviewsLink(Guid showId)
        {
            return string.Format("/ShowReviews.aspx?showId={0}", showId);
        }

        public string ShowReviewsLink(DateTime showDate)
        {
            return string.Format("/ShowReviews.aspx?showDate={0}", showDate.ToShortDateString());
        }

        public string SongReviewsLink(Guid setSongId)
        {
            return string.Format("/MyPhishMarket/SongReviews.aspx?setSongId={0}", setSongId);
        }

        #endregion

        #region Tour Links

        public string PredictTourLink()
        {
            return "/Tour/PredictTour.aspx";
        }

        public string GetScoreLink(Guid guessWholeShowId, string returnUrl)
        {
            return string.Format("/Tour/GetScore.aspx?gid={0}&return={1}", guessWholeShowId, returnUrl);
        }

        public string AddSongsToSetControlLink(Guid setId, string returnUrl)
        {
            return string.Format("/Tour/AddSongsToSet.aspx?id={0}&return={1}", setId, returnUrl);
        }

        public string PredictShowLink(Guid showId)
        {
            return string.Format("/Tour/PredictShow.aspx?id={0}", showId.ToString());
        }

        public string PredictShowWholeShowLink(Guid showId)
        {
            return string.Format("/Tour/PredictWholeShow.aspx?id={0}", showId.ToString());
        }

        public string PredictShowSetBasedShowLink(Guid showId)
        {
            return string.Format("/Tour/PredictSetBasedShow.aspx?id={0}", showId.ToString());
        }

        #endregion

        #region Admin Links

        public string AddSetsToShowLink(Guid showId)
        {
            return string.Format("/Admin/AddSetsToShow.aspx?id={0}", showId);
        }

        public string AdminCreatePostLink()
        {
            return "/Admin/CreatePost.aspx";
        }

        public string AdminCreateSetLink()
        {
            return "/Admin/CreateSet.aspx";
        }

        public string AdminCreateGuessWholeShowLink()
        {
            return "/Admin/CreateGuessWholeShow.aspx";
        }

        public string AdminCreateShowLink()
        {
            return "/Admin/CreateShow.aspx";
        }

        public string AdminCreateTopicLink()
        {
            return "/Admin/CreateTopic.aspx";
        }

        public string AdminCreateTourLink()
        {
            return "/Admin/CreateTour.aspx";
        }

        public string AdminCreateSongLink()
        {
            return "/Admin/CreateSong.aspx";
        }

        public string AddSetToGuessLink(Guid setId)
        {
            return string.Format("/Admin/CreateGuessWholeShow.aspx?id={0}", setId);
        }

        #endregion

    }
}
