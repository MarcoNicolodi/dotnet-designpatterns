using System;
using Xunit;
using ChainOfResponsability;

namespace ChainOfResponsibilityTeMatchingsts
{
    public class UnitTest1
    {
        [Fact(DisplayName = @"
            GIVEN that the I have the bypass authority
            WHEN I sign in
            THEN I should be authorized
        ")]
        public void LoginRequestChain_ShouldBypass()
        {
            var request = LoginRequest.BypassLogin;
            var result = Main.Run(request);
            Assert.True(result);
        }

        [Fact(DisplayName = @"
            GIVEN that sign in through Active Directory
            WHEN I have set my Active Directory configurations
            THEN I should be authorized
        ")]
        public void LoginRequestChain_ShouldAuthorizeActiveDirectory()
        {
            var request = LoginRequest.AuthorizeAD;
            var result = Main.Run(request);
            Assert.True(result);
        }

        [Fact(DisplayName = @"
            GIVEN that sign in through Active Directory
            WHEN I havent set my Active Directory configurations
            THEN I should not be authorized
        ")]
        public void LoginRequestChain_ShouldNotAuthorizeActiveDirectory()
        {
            var request = LoginRequest.UnauthorizeAD;
            var result = Main.Run(request);
            Assert.False(result);
        }

        [Fact(DisplayName = @"
            GIVEN that sign in through my credentials
            WHEN my credentails match
            THEN I should be authorized
        ")]
        public void LoginRequestChain_ShouldAuthorizeMatchingCredentails()
        {
            var request = LoginRequest.MatchingCredentials;
            var result = Main.Run(request);
            Assert.True(result);
        }

        [Fact(DisplayName = @"
            GIVEN that sign in through my credentials
            WHEN my credentails doent match
            THEN I should not be authorized
        ")]
        public void LoginRequestChain_ShouldNotAuthorizeNonMatchingCredentails()
        {
            var request = LoginRequest.NonMatchingCredentials;
            var result = Main.Run(request);
            Assert.False(result);
        }
    }
}
