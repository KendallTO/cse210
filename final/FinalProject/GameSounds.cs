using System;
using System.IO;
using System.Media;

public class GameSounds
{
    private const string BackgroundMusicFileName = "BackGroundMusic.wav";
    private const string FightMusicFileName = "FightMusic.wav";
    private static SoundPlayer _backgroundPlayer;
    private static bool _backgroundMusicEnabled;

    private static string GetSoundPath(string fileName)
    {
        return Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds", fileName);
    }

    public static void PlayBackgroundMusic()
    {
        try
        {
            string soundPath = GetSoundPath(BackgroundMusicFileName);
            if (!File.Exists(soundPath))
            {
                Console.WriteLine($"Background music file not found: {soundPath}");
                return;
            }

            _backgroundMusicEnabled = true;
            _backgroundPlayer?.Stop();
            _backgroundPlayer = new SoundPlayer(soundPath);
            _backgroundPlayer.Load();
            _backgroundPlayer.PlayLooping();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audio issue with background music: {ex.Message}");
        }
    }

    public static void StopBackgroundMusic()
    {
        _backgroundMusicEnabled = false;
        _backgroundPlayer?.Stop();
    }

    private static void ResumeBackgroundMusic()
    {
        if (_backgroundMusicEnabled && _backgroundPlayer != null)
        {
            _backgroundPlayer.PlayLooping();
        }
    }

    public static void PlayFightMusic()
    {
        try
        {
            string soundPath = GetSoundPath(FightMusicFileName);
            if (!File.Exists(soundPath))
            {
                Console.WriteLine($"Fight music file not found: {soundPath}");
                return;
            }

            _backgroundMusicEnabled = true;
            _backgroundPlayer?.Stop();
            _backgroundPlayer = new SoundPlayer(soundPath);
            _backgroundPlayer.Load();
            _backgroundPlayer.PlayLooping();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audio issue with fight music: {ex.Message}");
        }
    }

    public static void PlayAttackSound()
    {
        if (!PlaySound("Attack.wav"))
        {
            Console.Beep(500, 200);
        }
    }

    public static void PlayQuickBattleSound()
    {
        if (!PlaySound("QuickBattle.wav", waitForCompletion: true))
        {
            Console.Beep(700, 400);
        }
    }

    public static void PlayDoorOpen()
    {
        if (!PlaySound("DoorOpening.wav", waitForCompletion: true))
        {
            Console.Beep(1000, 150);
        }
    }

    public static void SaleComplete()
    {
        if (!PlaySound("SaleComplete.wav"))
        {
            Console.Beep(800, 300);
        }
    }

    public static void PlayDoorHandleRattle()
    {
        if (!PlaySound("DoorHandleRattle.wav"))
        {
            Console.Beep(600, 200);
        }
    }

    public static bool PlaySound(string fileName, bool waitForCompletion = false)
    {
        string soundPath = GetSoundPath(fileName);

        try
        {
            if (!File.Exists(soundPath))
            {
                Console.WriteLine($"Sound file not found: {soundPath}");
                return false;
            }

            using var sound = new SoundPlayer(soundPath);
            sound.Load();

            bool shouldResumeBackgroundMusic = _backgroundMusicEnabled && fileName != BackgroundMusicFileName;

            if (waitForCompletion || shouldResumeBackgroundMusic)
            {
                sound.PlaySync();

                if (shouldResumeBackgroundMusic)
                {
                    ResumeBackgroundMusic();
                }
            }
            else
            {
                sound.Play();
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audio issue with '{fileName}': {ex.Message}");
            return false;
        }
    }
}