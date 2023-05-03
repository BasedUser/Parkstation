namespace Content.Shared.Chat
{
    /// <summary>
    ///     Represents chat channels that the player can filter chat tabs by.
    /// </summary>
    [Flags]
    public enum ChatChannel : ushort
    {
        None = 0,

        /// <summary>
        ///     Chat heard by players within earshot
        /// </summary>
        Local = 1 << 0,

        /// <summary>
        ///     Chat heard by players right next to each other
        /// </summary>
        Whisper = 1 << 1,

        /// <summary>
        ///     Messages from the server
        /// </summary>
        Server = 1 << 2,

        /// <summary>
        ///     Damage messages
        /// </summary>
        Damage = 1 << 3,

        /// <summary>
        ///     Radio messages
        /// </summary>
        Radio = 1 << 4,

        /// <summary>
        ///     Local out-of-character channel
        /// </summary>
        LOOC = 1 << 5,

        /// <summary>
        ///     Out-of-character channel
        /// </summary>
        OOC = 1 << 6,

        /// <summary>
        ///     Visual events the player can see.
        ///     Basically like visual_message in SS13.
        /// </summary>
        Visual = 1 << 7,

        /// <summary>
        ///     Emotes
        /// </summary>
        Emotes = 1 << 8,

        /// <summary>
        ///     Deadchat
        /// </summary>
        Dead = 1 << 9,

        /// <summary>
        ///     Misc admin messages
        /// </summary>
        Admin = 1 << 10,

        /// <summary>
        ///     Admin alerts, messages likely of elevated importance to admins
        /// </summary>
        AdminAlert = 1 << 11,

        /// <summary>
        ///     Admin chat
        /// </summary>
        AdminChat = 1 << 12,

        /// <summary>
        ///     Unspecified.
        /// </summary>
        Unspecified = 1 << 13,

        /// <summary>
        ///     Telepathic channel for all psionic entities.
        /// </summary>
        Telepathic = 1 << 14,

        /// <summary>
        ///     Empathy channel for Shadowkin.
        /// </summary>
        Empathy = 1 << 15,

        /// <summary>
        ///     Channels considered to be IC.
        /// </summary>
        IC = Local | Whisper | Radio | Dead | Emotes | Damage | Visual | Telepathic | Empathy,
    }
}
