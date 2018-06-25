using System;
using CoreGraphics;
using UIKit;

namespace Umbrella.iOS.Extensions
{
    public class NoCaretField : UITextField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoCaretField"/> class.
        /// </summary>
        public NoCaretField() : base(default(CGRect))
        {
        }

        /// <summary>
        /// Gets the caret rect for position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>RectangleF.</returns>
        public override CGRect GetCaretRectForPosition(UITextPosition position)
        {
            return default(CGRect);
        }
    }
}
