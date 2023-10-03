using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();
    [SerializeField] SpriteInfo player;

    [SerializeField] public bool isAABB;


    // Update is called once per frame
    void Update()
    {
        // reset player status before checking
        player.isColliding = false;

        // loop thru all objects for collision
        foreach (var sprite in collidables)
        {
            if (isAABB)       // Using AABB
            {
                // if the player hit a sprite, they're both colliding
                if (AABBCheck(player, sprite))
                {
                    player.isColliding = true;
                    sprite.isColliding = true;
                }
                else
                {
                    sprite.isColliding = false;
                }
            }
            else              // Using Circle Collider
            {
                // if the player hit a sprite, they're both colliding
                if (CircleCollision(player, sprite))
                {
                    player.isColliding = true;
                    sprite.isColliding = true;
                }
                else
                {
                    sprite.isColliding = false;
                }
            }

            // draw sprite the correct color (red if colliding, clear if not)
            if (sprite.isColliding)
            {
                sprite.renderer.color = Color.red;
            }
            else
            {
                sprite.renderer.color = Color.white;
            }
        }

        // now handle the player
        if (player.isColliding)
        {
            player.renderer.color = Color.red;
        }
        else
        {
            player.renderer.color = Color.white;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (isAABB)
        {
            foreach (var sprite in collidables)
            {
                if (sprite.isColliding)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.green;
                }

                Gizmos.DrawWireCube(sprite.renderer.transform.position, sprite.renderer.size);
            }

            if (player.isColliding)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(player.renderer.transform.position, player.renderer.size);
        }
        else
        {
            foreach (var sprite in collidables)
            {
                if (sprite.isColliding)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.green;
                }

                Gizmos.DrawWireSphere(sprite.renderer.transform.position, sprite.radius);
            }

            if (player.isColliding)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireSphere(player.renderer.transform.position, player.radius);
        }
    }


    /// <summary>
    /// Checks using the AABB algorithm if sprites a and b are colliding
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        if (spriteA != null && spriteB != null)
        {
            if (spriteB.renderer.bounds.min.x < spriteA.renderer.bounds.max.x &&
                spriteB.renderer.bounds.max.x > spriteA.renderer.bounds.min.x &&
                spriteB.renderer.bounds.max.y > spriteA.renderer.bounds.min.y &&
                spriteB.renderer.bounds.min.y < spriteA.renderer.bounds.max.y)
            {
                return true;
            }
        }

        return false;
    }

    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(spriteA.transform.position.x - spriteB.transform.position.x, 2) 
            + Mathf.Pow(spriteA.transform.position.y - spriteB.transform.position.y, 2));

        if (distance < spriteA.radius + spriteB.radius)
        {
            return true;
        }

        return false;
    }
}
