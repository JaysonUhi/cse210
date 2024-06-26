using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string>_prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Reflect on a recent conversation that left a lasting impression on you. What was discussed, and how did it affect your perspective?",
            "Describe a challenge you faced today. How did you navigate it, and what did you learn from the experience?",
            "Write about a place you visited recently. What sights, sounds, and feelings stood out to you the most?",
            "Reflect on a book, movie, or piece of art that resonated with you recently. What themes or messages spoke to you, and why?",
            "Describe a skill or hobby you've been developing. What progress have you made, and how does it make you feel?",
            "Write about a goal you achieved recently. What steps did you take to accomplish it, and what did you learn along the way?",
            "Reflect on a moment when you felt grateful today. What or who sparked this feeling, and how did it impact your day?",
            "Write about a decision you made recently that you're proud of. What factors influenced your choice, and how did it turn out?",
            "Describe a setback or disappointment you faced recently. How did you cope with it, and what lessons did you take away from the experience?",
            "Reflect on a new perspective or insight you gained recently. How has this new understanding influenced your thoughts or actions?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}