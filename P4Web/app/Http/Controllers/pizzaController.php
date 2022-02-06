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
    }

    public function show($id)
    {
        $pizzas = DB::table('pizzas')->get();


        return view('show',['pizza' => $pizzas[$id]]);
    }

    public function cart($id)
    {
        $pizzas = DB::table('pizzas')->get();

        return view('homepage', ['order'=>$pizzas[$id]]);
    }
    //
}
