﻿namespace Business.Producer
{
    public class ProductCreatedEvent
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
