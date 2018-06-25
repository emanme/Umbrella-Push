using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class PrivacyPolicyPage : ContentPage
    {
        public PrivacyPolicyPage()
        {
            InitializeComponent();

            string htmlText = "<h2>Welcome to Umbrella Support!</h2>" +
                "<h3>Your privacy is critically important to us.</h3>" +
                "Umbrella Support is located at:<br/><address> " +
                "Umbrella Support<br/>8 Deer Park Road Wimbledon<br/>02030120251" +
                "</address><p>It is Umbrella Support’s policy to respect your " +
                "privacy regarding any information we may collect while " +
                "operating our website. This Privacy Policy applies to " +
                "<a href=\"http://www.umbrellasupport.co.uk/\">www.umbrellasupport.co.uk/</a> " +
                "(hereinafter, \"us\", \"we\", or \"www.umbrellasupport.co.uk/\"). " +
                "We respect your privacy and are committed to protecting personally " +
                "identifiable information you may provide us through the Website. " +
                "We have adopted this privacy policy (\"Privacy Policy\") to explain " +
                "what information may be collected on our Website, how we use this information, " +
                "and under what circumstances we may disclose the information to third parties. " +
                "This Privacy Policy applies only to information we collect through " +
                "the Website and does not apply to our collection of information " +
                "from other sources.</p><p>This Privacy Policy, together with the " +
                "Terms and conditions posted on our Website, set forth the general " +
                "rules and policies governing your use of our Website. Depending on " +
                "your activities when visiting our Website, you may be required to " +
                "agree to additional terms and conditions.</p><h2>Website Visitors</h2>" +
                "<p>Like most website operators, Umbrella Support collects " +
                "non-personally-identifying information of the sort that web " +
                "browsers and servers typically make available, such as the " +
                "browser type, language preference, referring site, and the date " +
                "and time of each visitor request. Umbrella Support’s purpose in " +
                "collecting non-personally identifying information is to better " +
                "understand how Umbrella Support’s visitors use its website. " +
                "From time to time, Umbrella Support may release non-personally-identifying " +
                "information in the aggregate, e.g., by publishing a report on " +
                "trends in the usage of its website.</p><p>Umbrella Support also " +
                "collects potentially personally-identifying information like " +
                "Internet Protocol (IP) addresses for logged in users and for " +
                "users leaving comments on http://www.umbrellasupport.co.uk/ blog posts. " +
                "Umbrella Support only discloses logged in user and commenter " +
                "IP addresses under the same circumstances that it uses and " +
                "discloses personally-identifying information as described below.</p>" +
                "<h2>Gathering of Personally-Identifying Information</h2>" +
                "<p>Certain visitors to Umbrella Support’s websites choose to " +
                "interact with Umbrella Support in ways that require Umbrella Support " +
                "to gather personally-identifying information. The amount and type of " +
                "information that Umbrella Support gathers depends on the nature of " +
                "the interaction. For example, we ask visitors who sign up for a " +
                "blog at http://www.umbrellasupport.co.uk/ to provide a username " +
                "and email address.</p><h2>Security</h2><p>The security of your " +
                "Personal Information is important to us, but remember that no " +
                "method of transmission over the Internet, or method of electronic " +
                "storage is 100% secure. While we strive to use commercially " +
                "acceptable means to protect your Personal Information, we cannot " +
                "guarantee its absolute security.</p><h2>Links To External Sites</h2>" +
                "<p>Our Service may contain links to external sites that are not " +
                "operated by us. If you click on a third party link, you will be " +
                "directed to that third party's site. We strongly advise you to " +
                "review the Privacy Policy and terms and conditions of every site " +
                "you visit.</p><p>We have no control over, and assume no responsibility " +
                "for the content, privacy policies or practices of any third " +
                "party sites, products or services.</p><h2>Protection of Certain " +
                "Personally-Identifying Information</h2><p>Umbrella Support discloses " +
                "potentially personally-identifying and personally-identifying " +
                "information only to those of its employees, contractors and " +
                "affiliated organizations that (i) need to know that information " +
                "in order to process it on Umbrella Support’s behalf or to provide " +
                "services available at Umbrella Support’s website, and (ii) that " +
                "have agreed not to disclose it to others. Some of those employees, " +
                "contractors and affiliated organizations may be located outside of " +
                "your home country; by using Umbrella Support’s website, you consent " +
                "to the transfer of such information to them. Umbrella Support will " +
                "not rent or sell potentially personally-identifying and " +
                "personally-identifying information to anyone. Other than to its " +
                "employees, contractors and affiliated organizations, as described " +
                "above, Umbrella Support discloses potentially personally-identifying " +
                "and personally-identifying information only in response to a " +
                "subpoena, court order or other governmental request, or when " +
                "Umbrella Support believes in good faith that disclosure is reasonably " +
                "necessary to protect the property or rights of Umbrella Support, " +
                "third parties or the public at large.</p><p>If you are a registered " +
                "user of http://www.umbrellasupport.co.uk/ and have supplied your " +
                "email address, Umbrella Support may occasionally send you an email " +
                "to tell you about new features, solicit your feedback, or just keep " +
                "you up to date with what’s going on with Umbrella Support and our " +
                "products. We primarily use our blog to communicate this type of " +
                "information, so we expect to keep this type of email to a minimum. " +
                "If you send us a request (for example via a support email or via one " +
                "of our feedback mechanisms), we reserve the right to publish it in " +
                "order to help us clarify or respond to your request or to help us " +
                "support other users. Umbrella Support takes all measures reasonably " +
                "necessary to protect against the unauthorized access, use, alteration " +
                "or destruction of potentially personally-identifying and " +
                "personally-identifying information.</p><h2>Aggregated Statistics</h2>" +
                "<p>Umbrella Support may collect statistics about the behavior of " +
                "visitors to its website. Umbrella Support may display this information " +
                "publicly or provide it to others. However, Umbrella Support does not " +
                "disclose your personally-identifying information.</p><h2>Affiliate Disclosure</h2>" +
                "<p>This site uses affiliate links and does earn a commission from certain " +
                "links. This does not affect your purchases or the price you may pay.</p>" +
                "<h2>Business Transfers</h2><p>If Umbrella Support, or substantially all " +
                "of its assets, were acquired, or in the unlikely event that " +
                "Umbrella Support goes out of business or enters bankruptcy, user " +
                "information would be one of the assets that is transferred or acquired " +
                "by a third party. You acknowledge that such transfers may occur, and " +
                "that any acquirer of Umbrella Support may continue to use your " +
                "personal information as set forth in this policy.</p>" +
                "<h2>Privacy Policy Changes</h2><p>Although most changes are likely " +
                "to be minor, Umbrella Support may change its Privacy Policy from time " +
                "to time, and in Umbrella Support’s sole discretion. Umbrella Support " +
                "encourages visitors to frequently check this page for any changes " +
                "to its Privacy Policy. Your continued use of this site after any " +
                "change in this Privacy Policy will constitute your acceptance of such change.</p>";
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = htmlText;
            HtmlWebView.Source = htmlSource;
        }
    }
}
