using System;
using static System.Console;

namespace Decorator
{
    public abstract class Weapon
    {
        protected int _damage;
        public virtual int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }

        }
        protected int _wheight;
        public virtual int Wheight
        {
            get
            {
                return _wheight;
            }
            set
            {
                _wheight = value;
            }

        }
        protected int _bulletCapacity;

        public virtual int BulletCapacity
        {
            get
            {
                return _bulletCapacity;
            }
            set
            {
                _bulletCapacity = value;
            }
        }

        public abstract void Shot();
    }

    public class PlasmaPistol : Weapon
    {
        public PlasmaPistol()
        {
            Damage = 10;
            Wheight = 15;
            BulletCapacity = 15;
        }

        public override void Shot()
        {
            WriteLine("Shot with a plasma pistol");
        }
    }

    public class SilencerDecorator : Weapon
    {
        private readonly Weapon _decoratee;

        public override int Wheight
        {
            get
            {
                return _wheight;
            }
            set
            {
                _wheight = value;
            }
        }

        public override int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }
        public SilencerDecorator(Weapon decoratee)
        {
            _decoratee = decoratee;
            Damage = _decoratee.Damage - 2;
            Wheight = _decoratee.Wheight + 3;
            BulletCapacity = _decoratee.BulletCapacity;
        }
        public override void Shot()
        {
            WriteLine("Shh... silenced shot");
            _decoratee.Shot();
        }
    }

    public class HollowClipsDecorator : Weapon
    {
        private readonly Weapon _decoratee;

        public override int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        public HollowClipsDecorator(Weapon decoratee)
        {
            _decoratee = decoratee;
            Damage = _decoratee.Damage + 15;
            BulletCapacity = _decoratee.BulletCapacity;
            Wheight = _decoratee.Wheight;
        }

        public override void Shot()
        {
            WriteLine("Deadly hollow clip shot");
            _decoratee.Shot();
        }
    }

    public class BananaClipsDecorator : Weapon
    {
        private readonly Weapon _decoratee;

        public override int Wheight
        {
            get
            {
                return _wheight;
            }
            set
            {
                _wheight = value;
            }
        }

        public override int BulletCapacity
        {
            get
            {
                return _bulletCapacity;
            }
            set
            {
                _bulletCapacity = value;
            }
        }

        public BananaClipsDecorator(Weapon decoratee)
        {
            _decoratee = decoratee;
            BulletCapacity = _decoratee.BulletCapacity + 10;
            Wheight = _decoratee.Wheight + 2;
            BulletCapacity = _decoratee.BulletCapacity;
        }

        public override void Shot()
        {
            WriteLine("Make them bullets rain bitch!");
            _decoratee.Shot();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vanillaPistol = new PlasmaPistol();
            vanillaPistol.Shot();

            WriteLine();

            var hollowClipsWeapon = new HollowClipsDecorator(new PlasmaPistol());
            hollowClipsWeapon.Shot();

            WriteLine();

            var silencedHollowClips = new SilencerDecorator(
                new HollowClipsDecorator(
                    new PlasmaPistol()
                )
            );
            silencedHollowClips.Shot();

            WriteLine();


            Weapon bigCapacity = new HollowClipsDecorator(
                new HollowClipsDecorator(
                    new SilencerDecorator(
                        new BananaClipsDecorator(
                            new PlasmaPistol()
                        )
                    )
                )
            );
            bigCapacity.Shot();
            WriteLine(bigCapacity.Damage);
            WriteLine(bigCapacity.BulletCapacity);
            WriteLine(bigCapacity.Wheight);
        }
    }
}
