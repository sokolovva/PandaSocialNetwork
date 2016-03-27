namespace Panda
{
    /// <summary>
    /// IPanda interface
    /// </summary>
    public interface IPanda
    {
        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the Email property.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the Gender property.
        /// </summary>
        Gender Gender { get; set; }

        /// <summary>
        /// Gets the IsMale property.
        /// </summary>
        bool IsMale { get;}

        /// <summary>
        /// Gets the IsFemale property.
        /// </summary>
        bool IsFemale { get; }
    }
}
