﻿using System.Linq.Expressions;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        WorkSpaceDbContext context;
        public BookingRepository(WorkSpaceDbContext context) 
        {
            this.context = context;
        }
        public void Delete(Booking entity)
        {
            if (entity != null)
            {
                context.Bookings.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            Booking item = GetById(id);
            if (item != null)
            {
                context.Bookings.Remove(item);
            }
        }

        public IQueryable<Booking> Get(Expression<Func<Booking, bool>> expression)
        {
            return context.Bookings.Where(expression);
        }

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return context.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Booking> GetByStartTime(TimeOnly startTime)
        {
            return context.Bookings.Where(x => x.StartTime == startTime);
        }

        public void Insert(Booking entity)
        {
            context.Bookings.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Booking entity)
        {
            context.Update(entity);
        }
    }
}
