using NaughtyAttributes;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField, Required] private Player _player;
    [SerializeField, Required] private Journal _journal;
    [SerializeField, Required] private GameObject _panel;
    [SerializeField, Required] private Transform _scrollViewContent;
    [SerializeField, Required] private JournalNoteUI _notePrefab;
    [SerializeField, Required] private JournalContent _content;

    private void Start()
    {
        _journal.OnNoteAdded.AddListener(AddNoteUI);

        _player.Input.Player.Journal.performed += (c) => _panel.SetActive(!_panel.activeInHierarchy);
    }

    private void AddNoteUI(NoteData noteData)
    {
        JournalNoteUI journalNoteUI = Instantiate(_notePrefab, _scrollViewContent.transform);
        journalNoteUI.Init(_content, noteData);
    }

    private void OnEnable()
    {
        if (_player.Input == null)
            return;

        _player.Input.Player.Journal.performed += (c) => _panel.SetActive(!_panel.activeInHierarchy);
    }

    private void OnDisable()
    {
        if (_player.Input == null)
            return;

        _player.Input.Player.Journal.performed -= (c) => _panel.SetActive(!_panel.activeInHierarchy);
    }
}
