using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _3_Modul.Lesson_8_February_10_2023.LessonTasks
{
    internal static class MediaPlayer
    {
        public static void playMusic(string filePath)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filePath;
            musicPlayer.Play();
        }
    }
}
