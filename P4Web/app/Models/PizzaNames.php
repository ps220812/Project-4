<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class pizzaNames extends Model
{
    use HasFactory;
    protected $table = 'pizzas';
    protected $fillable = [
        'id',
        'pizza_name',
    ];}
