using System;
using System.Linq;

namespace ChainOfResponsability
{
    public abstract class RuleHandler<TRequest, TReturn>
    {
        private RuleHandler<TRequest, TReturn> _nextHandler;

        public RuleHandler<TRequest, TReturn> SetNext(RuleHandler<TRequest, TReturn> handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }

        public virtual TReturn Run(TRequest request) => _nextHandler.Run(request);
    }

    public class LoginRequest
    {
        public LoginRequest(string user, string password, bool bypass, bool isActiveDirectory, bool hasActiveDirectory)
        {
            User = user;
            Password = password;
            Bypass = bypass;
            IsActiveDirectory = isActiveDirectory;
            HasActiveDirectory = hasActiveDirectory;
        }

        public string User { get; }
        public string Password { get; }
        public bool Bypass { get; }
        public bool IsActiveDirectory { get; }
        public bool HasActiveDirectory { get; }

        public static LoginRequest BypassLogin => new LoginRequest(null, null, true, false, false);
        public static LoginRequest AuthorizeAD => new LoginRequest(null, null, false, true, true);
        public static LoginRequest UnauthorizeAD => new LoginRequest(null, null, false, true, false);
        public static LoginRequest MatchingCredentials => new LoginRequest("match", "match", false, false, false);
        public static LoginRequest NonMatchingCredentials => new LoginRequest("match", "nonmatch", false, false, false);
    }

    public class Bypass : RuleHandler<LoginRequest, bool>
    {
        public override bool Run(LoginRequest request)
        {
            if (request.Bypass)
                return true;
            else
                return base.Run(request);
        }
    }

    public class ActiveDirectory : RuleHandler<LoginRequest, bool>
    {
        public override bool Run(LoginRequest request)
        {
            if (request.IsActiveDirectory)
            {
                return request.HasActiveDirectory;
            }
            else
                return base.Run(request);
        }
    }

    public class CredentialsCheck : RuleHandler<LoginRequest, bool>
    {
        public override bool Run(LoginRequest request) => CredentialsMatch(request.User, request.Password);

        private bool CredentialsMatch(string username, string password) => username == password;
    }

    public class Main
    {
        public static bool Run(LoginRequest request)
        {
            var rule = new Bypass();
            rule
                .SetNext(new ActiveDirectory())
                .SetNext(new CredentialsCheck())
                .Run(request);
            return rule.Run(request);
        }
    }

}

