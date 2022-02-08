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
        $pizzas = DB::table('orders')
            ->insert([
                'status_id'=>1,
                'pizza_id'=>$id
            ]);



        return view('show',['pizza' => $pizzas[$id]]);
    }

    public function orderStatus()
    {
        $order = DB::table('orders')
            ->join('order_status', 'orders.status_id', '=', 'order_status.id')
            ->join('pizzas', 'orders.pizza_id', '=', 'pizzas.id')
            ->orderBy('orders.id', 'DESC')
            ->first();

        return view('status',['order' => $order]);
    }

    public function cancelOrder()
    {
        DB::table('orders')
            ->orderBy('orders.id', 'DESC')
            ->limit(1)
            ->delete();
    }

    public function orderPizza($id)
    {
        DB::table('orders')
            ->insert([
                'status_id'=>1,
                'pizza_id'=>$id
            ]);
        $order = DB::table('orders')
            ->join('order_status', 'orders.status_id', '=', 'order_status.id')
            ->join('pizzas', 'orders.pizza_id', '=', 'pizzas.id')
            ->orderBy('orders.id', 'DESC')
            ->first();
        return view('status',['order' => $order]);
    }
    //
}
