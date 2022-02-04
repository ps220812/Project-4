<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class pizzaDisplay extends Model
{
    use HasFactory;
    protected $table = 'pizza_ingredients';
    protected $fillable = [
        'id',
        'pizza_id',
        'item_id',
    ];
}
