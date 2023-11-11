using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class BlockOfKnowledgeController : Controller
    {
        private readonly IBlockOfKnowledgeService _blockOfKnowledgeService;
        public BlockOfKnowledgeController(IBlockOfKnowledgeService blockOfKnowledgeService)
        {
            _blockOfKnowledgeService = blockOfKnowledgeService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<BlockOfKnowledgeDto> list = JsonConvert.DeserializeObject<List<BlockOfKnowledgeDto>>(Convert.ToString(response.Result));

                    return View(list);
                }
                return View();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new BlockOfKnowledgeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlockOfKnowledgeDto blockOfKnowledgeDto)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.CreateAsync(blockOfKnowledgeDto);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create BlockOfKnowledge successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.GetByIdAsync(id);
                if(response != null && response.IsSuccess)
                {
                    BlockOfKnowledgeDto value = JsonConvert.DeserializeObject<BlockOfKnowledgeDto>(Convert.ToString(response.Result));
                    return View(value);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlockOfKnowledgeDto blockOfKnowledgeDto)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.UpdateAsync(blockOfKnowledgeDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Update BlockOfKnowledge successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    BlockOfKnowledgeDto value = JsonConvert.DeserializeObject<BlockOfKnowledgeDto>(Convert.ToString(response.Result));
                    return View(value);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    BlockOfKnowledgeDto value = JsonConvert.DeserializeObject<BlockOfKnowledgeDto>(Convert.ToString(response.Result));
                    return View(value);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlockOfKnowledgeDto blockOfKnowledgeDto)
        {
            try
            {
                ResponseDto response = await _blockOfKnowledgeService.DeleteAsync(blockOfKnowledgeDto.BlockOfKnowledgeId);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete BlockOfKnowledge successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
