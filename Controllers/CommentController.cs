﻿using Microsoft.AspNetCore.Mvc;
using StockMarket.Dtos.Comment;
using StockMarket.Interface;
using StockMarket.Mappers;

namespace StockMarket.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepo)
        {
            _commentRepository = commentRepository;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _commentRepository.getAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepository.getByIdAsync(id);

            if(comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> createComment([FromRoute] int stockId, CreateCommentDto commentDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }

            var commentModel = commentDto.ToCommentFromCreate(stockId);

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(getById), new {id= commentModel.Id}, commentModel.ToCommentDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto  )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepository.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment == null)
            {
                return NotFound("Comment not found");
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteComment([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentModel = await _commentRepository.DeleteAsync(id);

            if(commentModel == null)
            {
                return NotFound("Comment doesnt exist");
            }

            return Ok(commentModel);
        }
    }
}
