using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Forum.Models;

namespace Forum.Models
{
    public class Comment
    {
        // Уникальный идентификатор для комментария
        [Key]
        public int Id { get; set; }

        // Текст комментария
        [Required]
        [StringLength(1000, ErrorMessage = "The content cannot be longer than 1000 characters.")]
        public string Content { get; set; }

        // Время создания комментария
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Внешний ключ для связи с постом
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }  // Навигационное свойство для связанного поста

        // Внешний ключ для связи с пользователем (если система предусматривает идентификацию пользователей)
        [ForeignKey("User")]
        public int? UserId { get; set; }  // Сделано nullable, если анонимные комментарии разрешены
        public User User { get; set; }  // Навигационное свойство для связанного пользователя
    }
}
