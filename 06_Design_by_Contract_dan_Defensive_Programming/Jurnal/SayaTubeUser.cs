using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TJ_modul6
{
    public class SayaTubeUser
    {
        private int id;
        private string username;
        private List<SayaTubeVideo> uploadedVideos;

        public SayaTubeUser(string username)
        {
            Debug.Assert(username != null, "Username tidak boleh null");
            Debug.Assert(username.Length <= 100, "Username maksimal 100 karakter");

            this.id = new Random().Next(10000, 99999);
            this.username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public void AddVideo(SayaTubeVideo video)
        {
            Debug.Assert(video != null, "Video tidak boleh null");
            Debug.Assert(video.GetPlayCount() < int.MaxValue, "Play count video tidak boleh lebih dari batas integer");

            if (video == null)
            {
                throw new ArgumentNullException("Video tidak boleh null");
            }

            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"Daftar video dari user: {username}");
            int count = Math.Min(uploadedVideos.Count, 8);
            for (int i = 0; i < count; i++)
            {
                uploadedVideos[i].PrintVideoDetails();
            }
        }
        public List<SayaTubeVideo> GetVideos()
        {
            return uploadedVideos;
        }
    }
}
