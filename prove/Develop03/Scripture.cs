public class Scripture
{
    private List<(ScriptureReference, List<Word>)> _scriptures;
    private Random _random;
    private int _currentScriptureIndex;

    public Scripture()
    {
        _scriptures = new List<(ScriptureReference, List<Word>)>();
        _random = new Random();
        _currentScriptureIndex = -1;
    }

    public void AddScripture(ScriptureReference reference, string text)
    {
        string[] wordArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<Word> words = wordArray.Select(word => new Word(word)).ToList();

        _scriptures.Add((reference, words));
    }

    public void SelectRandomScripture()
    {
        if (_scriptures.Count > 0)
        {
            _currentScriptureIndex = _random.Next(0, _scriptures.Count);
        }
    }

    public void HideNextRandomWord()
    {
        if (_currentScriptureIndex != -1)
        {
            var (reference, words) = _scriptures[_currentScriptureIndex];

            List<Word> visibleWords = words.Where(word => !word.IsHidden()).ToList();

            if (visibleWords.Count > 0)
            {
                int wordIndex = _random.Next(0, visibleWords.Count);
                visibleWords[wordIndex].Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        if (_currentScriptureIndex != -1)
        {
            var (reference, words) = _scriptures[_currentScriptureIndex];

            string referenceString = reference.ToString();
            List<string> displayWords = words.Select(word => word.GetDisplayText()).ToList();
            string scriptureText = string.Join(" ", displayWords);

            return $"{referenceString} - {scriptureText}";
        }
        else
        {
            return "No scripture selected.";
        }
    }

    public bool IsCompletelyHidden()
    {
        if (_currentScriptureIndex != -1)
        {
            var (_, words) = _scriptures[_currentScriptureIndex];
            return words.All(word => word.IsHidden());
        }
        return false;
    }
}
