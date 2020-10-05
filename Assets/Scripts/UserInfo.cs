using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Used for storing all User information including preferences
 */
public class UserInfo : MonoBehaviour
{
    private string PlayerName;
    private string UserId;
    private Monster UsersMonster;
    private List<string> Notifications;
    private bool hasNewNotifications;
    private List<Monster> ReceivedMonsters;
    private Configurable Preferences;

    /*
    The class for configurable preferences which can be stored in GameSparks
    as part of the player extra data.
     */
    public class Configurable
    {
        public int Interval {get; set;}
        public int Music {get; set;}
        public int Volume {get; set;}
        public long LastRecv {get; set;}

        public Configurable()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            this.LastRecv = (long)t.TotalMilliseconds;
            this.Interval = 0;
            this.Music = 0;
            this.Volume = 50;
        }

        public Configurable(int interval, int music, int volume, long lastrecv)
        {
            this.Interval = interval;
            this.Music = music;
            this.Volume = volume;
            this.LastRecv = lastrecv;
        }
    }

    public class Monster
    {
        public string userId {get; set;}
        public string name {get; set;}
        public int eyes {get; set;}
        public int ears {get; set;}
        public int horn {get; set;}
        public int tail {get; set;}
        public string color {get; set;}
        //public string colorEyes { get; set; }
        //public string colorHorn { get; set; }


        public Monster (string userId, string name, int eyes, int ears, int horn, int tail, string color //, string colorEyes, string colorHorn
            ) {
        	this.userId = userId;
        	this.name = name;
        	this.eyes = eyes;
        	this.ears = ears;
        	this.horn = horn;
        	this.tail = tail;
        	this.color = color;
            //this.colorEyes = colorEyes;
            //this.colorHorn = colorHorn;


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerName = null;
        UserId = null;
        Notifications = new List<string>();
        ReceivedMonsters = null;
        UsersMonster = null;
        Preferences = new Configurable();
    }

    /*
    Get and set methods of class properties
    Set methods should check for input format and return boolean
     */
    public string getPlayerName(){return this.PlayerName;}
    public bool setPlayerName(string playerName)
    {
        this.PlayerName = playerName;
        return true;
    }

    public string getUserId(){return this.UserId;}
    public bool setUserId(string userId)
    {
        this.UserId = userId;
        return true;
    }

    public Monster getUsersMonster()
    {
        return this.UsersMonster;
    }
    public void setUsersMonster(Monster monster)
    {
        this.UsersMonster = monster;
    }

    public bool checkNewNotifications(){
        bool res = this.hasNewNotifications;
        this.hasNewNotifications = false;
        return res;
    }
    public List<string> getNotifications(){return this.Notifications;}
    public bool setNotifications(List<string> Notifications)
    {
        this.Notifications = Notifications;
        this.hasNewNotifications = true;
        return true;
    }
    public bool addNotification(string Notification)
    {
        this.Notifications.Add(Notification);
        this.hasNewNotifications = true;
        return true;
    }

    public List<Monster> getMonsters(){return this.ReceivedMonsters;}
    public bool setMonsters(List<Monster> monsters)
    {
        this.ReceivedMonsters = monsters;
        return true;
    }

    public Configurable getPreferences(){return this.Preferences;} 
    public bool setPreferences(Configurable preferences)
    {
        this.Preferences = preferences;
        return true;
    }

}
