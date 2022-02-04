<?php

namespace App\Http\Controllers;

use app\models\pizzaNames;
use Illuminate\Support\Facades\DB;
use Illuminate\Http\Request;

class pizzaController extends Controller
{
    public function index()
    {
        $pizzas = DB::table('pizzas')->get();
        return view('homepage', ['pizzas'=>$pizzas]);
        $items = DB::table('items')->get();
        return view('homepage', ['items'=>$items]);
    }
    //
}
