using System;
using System.Collections.Generic;
using System.Drawing;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;
using prjFortrex.GameEngine.GamePlay.Objects.Items;

namespace prjFortrex.GameEngine.GamePlay.Objects.Entities
{
    public interface IMobileEntity
    {
        Point CurrentPosition { get; set; }

        void MoveEntity(Direction entityDirection);
        void MoveEntity(Direction entityDirection, int speed);
    }

    public abstract class EntityBase : IMobileEntity, IDisposable
    {
        #region IMobileEntity Implementation

        public Point CurrentPosition { get; set; }

        public Rectangle EntitySize;



        public virtual void MoveEntity(Direction entityDirection)
        {
            MoveEntity(entityDirection, 20);
        }

        public virtual void MoveEntity(Direction entityDirection, int amount)
        {
            Point nextPosition;

            switch (entityDirection)
            {
                case Direction.Up:
                    nextPosition = new Point(CurrentPosition.X, CurrentPosition.Y - amount);
                    break;
                case Direction.Down:
                    nextPosition = new Point(CurrentPosition.X, CurrentPosition.Y + amount);
                    break;
                case Direction.Left:
                    nextPosition = new Point(CurrentPosition.X - amount, CurrentPosition.Y);
                    break;
                case Direction.Right:
                    nextPosition = new Point(CurrentPosition.X + amount, CurrentPosition.Y);
                    break;
                default:
                    return;
            }

            CurrentPosition = nextPosition;
            EntitySize.X = CurrentPosition.X;
            EntitySize.Y = CurrentPosition.Y;

            // The command to move is sent to the server by the class inheriting this base entity class.
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                EntityPicture.Dispose();
            }
        }

        #endregion

        #region Constructors

        protected EntityBase()
        {
            EntitySize = new Rectangle(0, 0, 50, 50);
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");
        }

        protected EntityBase(Rectangle size)
        {
            EntitySize = size;
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");


        }

        #endregion

        #region Properties

        public Image EntityPicture { get; set; }


        public int CurrencyCount { get; set; }
        

        public List<ItemBase> InventoryList = new List<ItemBase>();

        


        #endregion
    }
}