<?php

namespace App\Http\Controllers;

use App\Models\orders;
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
    public function orderStatus()
    {
        $order = DB::table('orders')
            ->join('order_status', 'orders.status_id', '=', 'order_status.id')
            ->join('pizzas', 'orders.pizza_id', '=', 'pizzas.id')
            ->orderBy('orders.id', 'DESC')
            ->first();
        return view('status',['order' => $order]);

    }

    public function cancelOrder($id)
    {
        $order = orders::find($id);
        $order->delete();
        $pizzas = DB::table('pizzas')->get();
        return view('homepage', ['pizzas'=>$pizzas]);
    }

    public function orderPizza($id)
    {
        $order = new orders;
        $order->status_id = 1;
        $order->pizza_id = $id;
        $order->save();
        $status = DB::table('orders')
            ->join('order_status', 'orders.status_id', '=', 'order_status.id')
            ->join('pizzas', 'orders.pizza_id', '=', 'pizzas.id')
            ->orderBy('orders.id', 'DESC')
            ->first();
        return view('status', ['order'=>$status]);
    }
    //
}
