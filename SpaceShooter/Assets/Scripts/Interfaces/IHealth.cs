﻿using System;


public class HealthChangedEventArgs : EventArgs
{
    public int CurrentHealth { get; private set; }

    public HealthChangedEventArgs(int currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}

public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);
    public interface IHealth
    {
    int CurrentHealth { get; set; }

    /// <summary>
    /// Reduces health when method is called.
    /// </summary>
    /// <param name="damage">Amount of health reduced</param>
    /// <returns>true if health reaches zero, false otherwise</returns>
    bool TakeDamage(int damage);

    event HealthChangedDelegate HealthChanged;
    }
