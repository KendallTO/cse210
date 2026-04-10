using System;
using System.IO;
using System.Media;

public class GameSounds
{
    private const string BackgroundMusicFileName = "BackGroundMusic.wav";
    private const string FightMusicFileName = "FightMusic.wav";
    private static SoundPlayer _backgroundPlayer;
    private static bool _backgroundMusicEnabled;
    private static bool AudioSupported => OperatingSystem.IsWindows();

    private static string GetSoundPath(string fileName)
    {
        return Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds", fileName);
    }

    public static void PlayBackgroundMusic()
    {
        if (!AudioSupported)
        {
            _backgroundMusicEnabled = false;
            return;
        }

        string soundPath = GetSoundPath(BackgroundMusicFileName);
        if (!File.Exists(soundPath))
        {
            _backgroundMusicEnabled = false;
            return;
        }

        try
        {
            _backgroundMusicEnabled = true;
            _backgroundPlayer?.Stop();
            _backgroundPlayer = new SoundPlayer(soundPath);
            _backgroundPlayer.Load();
            _backgroundPlayer.PlayLooping();
        }
        catch
        {
            _backgroundMusicEnabled = false;
            _backgroundPlayer = null;
        }
    }

    public static void StopBackgroundMusic()
    {
        _backgroundMusicEnabled = false;
        _backgroundPlayer?.Stop();
    }

    private static void ResumeBackgroundMusic()
    {
        if (AudioSupported && _backgroundMusicEnabled && _backgroundPlayer != null)
        {
            _backgroundPlayer.PlayLooping();
        }
    }

    public static void PlayFightMusic()
    {
        if (!AudioSupported)
        {
            _backgroundMusicEnabled = false;
            return;
        }

        string soundPath = GetSoundPath(FightMusicFileName);
        if (!File.Exists(soundPath))
        {
            _backgroundMusicEnabled = false;
            return;
        }

        try
        {
            _backgroundMusicEnabled = true;
            _backgroundPlayer?.Stop();
            _backgroundPlayer = new SoundPlayer(soundPath);
            _backgroundPlayer.Load();
            _backgroundPlayer.PlayLooping();
        }
        catch
        {
            _backgroundMusicEnabled = false;
            _backgroundPlayer = null;
        }
    }

    public static void PlayAttackSound()
    {
        PlaySound("Attack.wav");
    }

    public static void PlayQuickBattleSound()
    {
        PlaySound("QuickBattle.wav", waitForCompletion: true);
    }

    public static void PlayDoorOpen()
    {
        PlaySound("DoorOpening.wav", waitForCompletion: true);
    }

    public static void SaleComplete()
    {
        PlaySound("SaleComplete.wav");
    }

    public static void PlayDoorHandleRattle()
    {
        PlaySound("DoorHandleRattle.wav");
    }

    public static bool PlaySound(string fileName, bool waitForCompletion = false)
    {
        if (!AudioSupported)
        {
            return false;
        }

        string soundPath = GetSoundPath(fileName);
        if (!File.Exists(soundPath))
        {
            return false;
        }

        try
        {
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
        catch
        {
            return false;
        }
    }
}